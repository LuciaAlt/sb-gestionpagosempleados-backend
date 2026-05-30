namespace SB.Entities.Empleados;

public class EmpleadoAsalariado : Empleado
{
    public override CodigoTipoEmpleado TipoCodigo => CodigoTipoEmpleado.Asalariado;
}
