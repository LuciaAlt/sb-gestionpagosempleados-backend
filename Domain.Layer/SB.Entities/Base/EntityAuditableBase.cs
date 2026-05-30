namespace SB.Entities.Base;

/// <summary>
/// Entidad base auditable. Todas las entidades del dominio heredan de aquí.
/// Los campos UsuarioRegistra/UsuarioModifica/FechaRegistra/FechaModifica se llenan
/// automáticamente vía AuditableInterceptor de EF Core en cada SaveChanges.
/// Borrado = baja lógica fuerte (no aparece en queries).
/// Activo = bandera de negocio (puede aparecer pero marcado como inactivo).
/// </summary>
public abstract class EntityAuditableBase : IEntityBase
{
    public int Id { get; set; }

    /// <summary>Usuario que creó el registro. Se llena automáticamente.</summary>
    public string UsuarioRegistra { get; set; } = string.Empty;

    /// <summary>Fecha de creación. Se llena automáticamente.</summary>
    public DateTimeOffset FechaRegistra { get; set; } = DateTimeOffset.Now;

    /// <summary>Usuario que modificó el registro por última vez.</summary>
    public string? UsuarioModifica { get; set; }

    /// <summary>Fecha de última modificación.</summary>
    public DateTimeOffset? FechaModifica { get; set; }

    /// <summary>Baja lógica fuerte: si es true, el registro se filtra de toda consulta.</summary>
    public bool Borrado { get; set; } = false;

    /// <summary>Bandera de negocio. Activo=false sigue siendo consultable pero deshabilitado.</summary>
    public bool Activo { get; set; } = true;
}
