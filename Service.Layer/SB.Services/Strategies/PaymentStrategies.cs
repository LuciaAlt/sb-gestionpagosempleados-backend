using SB.Entities.Empleados;
using SB.Models.Helpers;

namespace SB.Services.Strategies;


public class SalariedPaymentStrategy : IPaymentStrategy
{
    public CodigoTipoEmpleado AppliesTo => CodigoTipoEmpleado.Asalariado;

    public PaymentResult Calculate(Empleado employee)
    {
        var salario = employee.SalarioSemanal;

        return new PaymentResult(
            salario,
            $"Salario semanal fijo: {salario:C}");
    }
}

public class HourlyPaymentStrategy : IPaymentStrategy
{
    public CodigoTipoEmpleado AppliesTo => CodigoTipoEmpleado.PorHoras;

    public PaymentResult Calculate(Empleado employee)
    {
        var sueldoPorHora = employee.SueldoPorHora;
        var horasTrabajadas = employee.HorasTrabajadas;

        if (horasTrabajadas <= Constants.Payment.HorasRegulares)
        {
            var pago = sueldoPorHora * horasTrabajadas;

            return new PaymentResult(
                pago,
                $"{sueldoPorHora:C} × {horasTrabajadas} h = {pago:C}");
        }

        var extras = horasTrabajadas - Constants.Payment.HorasRegulares;
        var regular = sueldoPorHora * Constants.Payment.HorasRegulares;
        var bono = sueldoPorHora * Constants.Payment.FactorHorasExtra * extras;
        var total = regular + bono;

        return new PaymentResult(
            total,
            $"({sueldoPorHora:C} × 40) + ({sueldoPorHora:C} × 1.5 × {extras}) = {regular:C} + {bono:C} = {total:C}");
    }
}
public class CommissionPaymentStrategy : IPaymentStrategy
{
    public CodigoTipoEmpleado AppliesTo => CodigoTipoEmpleado.PorComision;

    public PaymentResult Calculate(Empleado employee)
    {
        var ventas = employee.VentasBrutas;
        var tarifa = employee.TarifaComision;
        var pago = ventas * tarifa;

        return new PaymentResult(
            pago,
            $"{ventas:C} × {tarifa:P2} = {pago:C}");
    }
}

public class BasePlusCommissionPaymentStrategy : IPaymentStrategy
{
    public CodigoTipoEmpleado AppliesTo => CodigoTipoEmpleado.AsalariadoPorComision;

    public PaymentResult Calculate(Empleado employee)
    {
        var ventas = employee.VentasBrutas;
        var tarifa = employee.TarifaComision;
        var salarioBase = employee.SalarioBase;

        var comision = ventas * tarifa;
        var bono = salarioBase * Constants.Payment.BonificacionAsalariadoComision;
        var pago = comision + salarioBase + bono;

        return new PaymentResult(
            pago,
            $"({ventas:C} × {tarifa:P2}) + {salarioBase:C} + ({salarioBase:C} × 10%) = {pago:C}");
    }
}
