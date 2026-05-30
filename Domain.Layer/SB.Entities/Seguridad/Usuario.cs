using SB.Entities.Base;

namespace SB.Entities.Seguridad;
public class Usuario : EntityAuditableBase
{
    public string NombreUsuario { get; set; } = string.Empty;
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string HashContrasena { get; set; } = string.Empty;
    public int RolId { get; set; }
    public Role? Rol { get; set; }
    public bool Bloqueado { get; set; } = false;
    public DateTimeOffset? FechaCambioContrasena { get; set; }
    public DateTimeOffset? UltimoAcceso { get; set; }
}
