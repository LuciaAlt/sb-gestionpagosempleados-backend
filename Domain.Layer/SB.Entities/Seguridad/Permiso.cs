using SB.Entities.Base;

namespace SB.Entities.Seguridad;

/// <summary>
/// Permiso granular (EMPLEADOS_CREAR, REPORTES_VER, etc).
/// Pertenece a un Module y se concede a roles vía RolePermission.
/// </summary>
public class Permiso : EntityAuditableBase
{
    public int ModuloId { get; set; }
    public Modulo? Modulo { get; set; }

    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;

    public ICollection<RolPermiso> RolePermisos { get; set; } = new List<RolPermiso>();
}
