using SB.Entities.Empleados;

namespace SB.Services.Strategies;

public interface IPaymentStrategyResolver
{
    IPaymentStrategy Resolve(CodigoTipoEmpleado type);
    PaymentResult Calculate(Empleado employee);
}

public class PaymentStrategyResolver : IPaymentStrategyResolver
{
    private readonly Dictionary<CodigoTipoEmpleado, IPaymentStrategy> _strategies;

    public PaymentStrategyResolver(IEnumerable<IPaymentStrategy> strategies)
        => _strategies = strategies.ToDictionary(s => s.AppliesTo);

    public IPaymentStrategy Resolve(CodigoTipoEmpleado type)
    {
        if (!_strategies.TryGetValue(type, out var s))
            throw new InvalidOperationException($"No hay strategy registrada para el tipo: {type}");
        return s;
    }

    public PaymentResult Calculate(Empleado employee) => Resolve(employee.TipoCodigo).Calculate(employee);
}
