using SB.Entities.Base;

namespace SB.Entities.Empleados;

/// <summary>
/// Entidad base de empleado. TPH: los 4 subtipos viven en la misma tabla
/// con discriminador EmployeeTypeId (que también es FK al catálogo).
/// </summary>
public abstract class Empleado : EntityAuditableBase
{
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string NumeroSeguroSocial { get; set; } = string.Empty;

    public int DepartmentoId { get; set; }
    public Departamento? Departmento { get; set; }

    public int TipoEmpleadoId { get; set; }
    public TipoEmpleado? TipoEmpleado { get; set; }

    public decimal SalarioSemanal { get; set; }
    public decimal SueldoPorHora { get; set; }
    public decimal HorasTrabajadas { get; set; }
    public decimal VentasBrutas { get; set; }
    public decimal TarifaComision { get; set; }
    public decimal SalarioBase { get; set; }
    public abstract CodigoTipoEmpleado TipoCodigo { get; }
}
