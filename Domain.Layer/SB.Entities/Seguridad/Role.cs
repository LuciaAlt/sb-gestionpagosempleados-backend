using SB.Entities.Base;

namespace SB.Entities.Seguridad;

public class Role : EntityAuditableBase
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public ICollection<RolPermiso> RolesPermisos { get; set; } = new List<RolPermiso>();
}
