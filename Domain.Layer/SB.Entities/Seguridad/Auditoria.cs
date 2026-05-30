using SB.Entities.Base;

namespace SB.Entities.Seguridad;

/// <summary>
/// Bitácora automática de acciones (CREATE, UPDATE, DELETE, LOGIN, LOGOUT).
/// Se llena automáticamente desde AuditableInterceptor en cada SaveChanges.
/// Cumple el requisito "la aplicación debe loggear todo lo que pase" a nivel BD.
/// </summary>
public class Auditoria : IEntityBase
{
    public int Id { get; set; }

    /// <summary>Usuario que realizó la acción. NULL si fue anónimo (ej. login fallido).</summary>
    public string? UsuarioRegistra { get; set; }

    /// <summary>LOGIN, LOGIN_FAIL, CREATE, UPDATE, DELETE, LOGOUT.</summary>
    public string Accion { get; set; } = string.Empty;

    /// <summary>Nombre de la entidad afectada (ej. "Employee", "User").</summary>
    public string Entidad { get; set; } = string.Empty;

    /// <summary>Id de la entidad afectada. NULL para acciones globales (LOGIN).</summary>
    public int? EntidadId { get; set; }

    /// <summary>JSON con los cambios realizados o detalle adicional.</summary>
    public string? Detalle { get; set; }

    /// <summary>IP de origen.</summary>
    public string? Ip { get; set; }

    public DateTimeOffset Fecha { get; set; } = DateTimeOffset.Now;
}
