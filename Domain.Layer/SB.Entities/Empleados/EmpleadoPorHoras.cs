namespace SB.Entities.Empleados;

public class EmpleadoPorHoras : Empleado
{
    public override CodigoTipoEmpleado TipoCodigo => CodigoTipoEmpleado.PorHoras;
}
