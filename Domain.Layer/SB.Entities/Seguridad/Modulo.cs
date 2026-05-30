using SB.Entities.Base;

namespace SB.Entities.Seguridad;

/// <summary>
/// Módulo del sistema (EMPLEADOS, REPORTES, USUARIOS).
/// Agrupa permisos para facilitar la administración.
/// </summary>
public class Modulo : EntityAuditableBase
{
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Icono { get; set; }
    public int Orden { get; set; }

    public ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
