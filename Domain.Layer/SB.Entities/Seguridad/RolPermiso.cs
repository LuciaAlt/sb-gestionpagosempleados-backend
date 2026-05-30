using SB.Entities.Base;

namespace SB.Entities.Seguridad;

/// <summary>
/// Tabla puente Roles N:N Permissions. La clave compuesta {RoleId, PermissionId}
/// se configura en RolePermissionConfiguration.
/// </summary>
public class RolPermiso : EntityAuditableBase
{

    public int RolId { get; set; }
    public Role? Rol { get; set; }

    public int PermisoId { get; set; }
    public Permiso? Permiso { get; set; }

    public DateTimeOffset FechaConcedida { get; set; } = DateTimeOffset.Now;
    public string UsuarioConcede { get; set; } = string.Empty;
}
