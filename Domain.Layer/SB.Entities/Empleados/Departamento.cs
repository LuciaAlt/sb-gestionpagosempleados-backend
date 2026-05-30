using SB.Entities.Base;

namespace SB.Entities.Empleados;

public class Departamento : EntityAuditableBase
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }

    public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
