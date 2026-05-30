using SB.Entities.Empleados;

namespace SB.Models.Dtos.RRHH;

public class EmpleadoDtos
{
    public int Id { get; set; }
    /// <example>Juan</example>
    public string Nombres { get; set; } = string.Empty;
    /// <example>Martínez</example>
    public string Apellidos { get; set; } = string.Empty;
    /// <example>001-9000001-1</example>
    public string NumeroSeguroSocial { get; set; } = string.Empty;
    /// <summary>1=Asalariado, 2=PorHoras, 3=PorComision, 4=AsalariadoPorComision</summary>
    public CodigoTipoEmpleado TipoEmpleadoCodigo { get; set; }
    public int DepartmentoId { get; set; }
    /// <summary>1=Asalariado, 2=PorHoras, 3=PorComision, 4=AsalariadoPorComision</summary>
    public int TipoEmpleadoId { get; set; }
    public string? DepartmentNombre { get; set; }
    public string? TipoEmpleadoNombre { get; set; }
    public bool Activo { get; set; } = true;
    public decimal SalarioSemanal { get; set; }
    public decimal SueldoPorHora { get; set; }
    public decimal HorasTrabajadas { get; set; }
    public decimal VentasBrutas { get; set; }
    public decimal TarifaComision { get; set; }
    public decimal SalarioBase { get; set; }

    /// <summary>Calculado en backend.</summary>
    public decimal PagoSemanal { get; set; }
}



