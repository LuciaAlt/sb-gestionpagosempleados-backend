using SB.Entities.Empleados;

namespace SB.Services.Strategies;

public record PaymentResult(decimal Amount, string Detail);

/// <summary>
/// Strategy Pattern: cada tipo de empleado implementa su propia regla.
/// Open/Closed Principle (OCP): nuevo tipo = nueva clase, sin tocar las existentes.
/// </summary>
public interface IPaymentStrategy
{
    CodigoTipoEmpleado AppliesTo { get; }
    PaymentResult Calculate(Empleado employee);
}
