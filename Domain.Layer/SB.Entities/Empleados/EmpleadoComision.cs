namespace SB.Entities.Empleados;

public class EmpleadoComision : Empleado
{
    public override CodigoTipoEmpleado TipoCodigo => CodigoTipoEmpleado.PorComision;
}
