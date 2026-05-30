namespace SB.Entities.Empleados;

public class BaseEmpleadoComision : Empleado
{
    public override CodigoTipoEmpleado TipoCodigo => CodigoTipoEmpleado.AsalariadoPorComision;
}
