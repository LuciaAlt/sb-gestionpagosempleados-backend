using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SB.Entities.Base;
using SB.Entities.Seguridad;
using SB.Models.Contracts;
using SB.Models.Helpers;

namespace SB.Repositories.Interceptors;

/// <summary>
/// Interceptor de EF Core que:
/// 1. Llena automáticamente UsuarioRegistra/FechaRegistra al insertar.
/// 2. Llena automáticamente UsuarioModifica/FechaModifica al actualizar.
/// 3. Convierte DELETE físico en SOFT DELETE (Borrado=true).
/// 4. Inserta automáticamente un AuditLog por cada CREATE/UPDATE/DELETE.
/// </summary>
public class AuditableInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUser;

    public AuditableInterceptor(ICurrentUserService currentUser) => _currentUser = currentUser;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        ProcessChanges(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return base.SavingChanges(eventData, result);

        ProcessChanges(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    private void ProcessChanges(DbContext context)
    {
        var ahora = DateTimeOffset.Now;
        var usuario = _currentUser.Username;
        var ip = _currentUser.Ip;
        var auditLogs = new List<Auditoria>();

        // Capturamos las entradas auditables (excluimos AuditLog para evitar recursión)
        var entries = context.ChangeTracker
            .Entries<EntityAuditableBase>()
            .Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted)
            .ToList();

        foreach (var entry in entries)
        {
            var entidad = entry.Entity.GetType().Name;
            var entidadId = entry.Entity.Id;

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.UsuarioRegistra = usuario;
                    entry.Entity.FechaRegistra = ahora;
                    auditLogs.Add(NewLog(Constants.AuditActions.Create, usuario, entidad, entidadId, SerializeNew(entry), ip, ahora));
                    break;

                case EntityState.Modified:
                    entry.Entity.UsuarioModifica = usuario;
                    entry.Entity.FechaModifica = ahora;
                    // No permitir reescribir los campos de creación
                    entry.Property(nameof(EntityAuditableBase.UsuarioRegistra)).IsModified = false;
                    entry.Property(nameof(EntityAuditableBase.FechaRegistra)).IsModified = false;

                    var detalle = SerializeChanges(entry);
                    var accion = entry.Entity.Borrado ? Constants.AuditActions.SoftDelete : Constants.AuditActions.Update;
                    auditLogs.Add(NewLog(accion, usuario, entidad, entidadId, detalle, ip, ahora));
                    break;

                case EntityState.Deleted:
                    // Convertir DELETE físico en SOFT DELETE
                    entry.State = EntityState.Modified;
                    entry.Entity.Borrado = true;
                    entry.Entity.UsuarioModifica = usuario;
                    entry.Entity.FechaModifica = ahora;
                    auditLogs.Add(NewLog(Constants.AuditActions.Delete, usuario, entidad, entidadId, null, ip, ahora));
                    break;
            }
        }

        if (auditLogs.Count > 0)
            context.Set<Auditoria>().AddRange(auditLogs);
    }

    private static Auditoria NewLog(string accion, string usuario, string entidad, int? entidadId, string? detalle, string? ip, DateTimeOffset fecha)
        => new()
        {
            Accion = accion,
            UsuarioRegistra = usuario,
            Entidad = entidad,
            EntidadId = entidadId,
            Detalle = detalle,
            Ip = ip,
            Fecha = fecha
        };

    private static string? SerializeNew(EntityEntry entry)
    {
        try
        {
            var values = entry.CurrentValues.Properties
                .Where(p => !IsAuditField(p.Name))
                .ToDictionary(p => p.Name, p => entry.CurrentValues[p]);
            return JsonSerializer.Serialize(values);
        }
        catch { return null; }
    }

    private static string? SerializeChanges(EntityEntry entry)
    {
        try
        {
            var changes = new Dictionary<string, object?>();
            foreach (var prop in entry.Properties)
            {
                if (!prop.IsModified) continue;
                if (IsAuditField(prop.Metadata.Name)) continue;
                changes[prop.Metadata.Name] = new { from = prop.OriginalValue, to = prop.CurrentValue };
            }
            return changes.Count == 0 ? null : JsonSerializer.Serialize(changes);
        }
        catch { return null; }
    }

    private static bool IsAuditField(string name) => name is
        nameof(EntityAuditableBase.UsuarioRegistra) or
        nameof(EntityAuditableBase.FechaRegistra) or
        nameof(EntityAuditableBase.UsuarioModifica) or
        nameof(EntityAuditableBase.FechaModifica);
}
