namespace SB.Entities.Empleados;

/// <summary>
/// Códigos estables de tipos de empleado. Coinciden con los IDs del catálogo
/// EmployeeTypes y sirven como discriminador TPH y para resolver strategies.
/// </summary>
public enum CodigoTipoEmpleado
{
    Asalariado = 1,
    PorHoras = 2,
    PorComision = 3,
    AsalariadoPorComision = 4
}
