using FluentAssertions;
using SB.Entities.Empleados;
using SB.Services.Strategies;
using Xunit;

namespace SB.Tests.Strategies;

public class PaymentStrategiesTests
{
    [Fact]
    public void Salaried_ReturnsFixedWeeklySalary()
    {
        var emp = new EmpleadoAsalariado { SalarioSemanal = 1500m };
        new SalariedPaymentStrategy().Calculate(emp).Amount.Should().Be(1500m);
    }

    [Theory]
    [InlineData(30, 20, 600)]
    [InlineData(40, 20, 800)]
    [InlineData(50, 20, 1100)]
    [InlineData(60, 15, 1050)]
    public void Hourly_AppliesOvertimeRule(decimal horas, decimal sueldo, decimal esperado)
    {
        var emp = new EmpleadoPorHoras { SueldoPorHora = sueldo, HorasTrabajadas = horas };
        new HourlyPaymentStrategy().Calculate(emp).Amount.Should().Be(esperado);
    }

    [Fact]
    public void Commission_IsSalesTimesRate()
    {
        var emp = new EmpleadoComision { VentasBrutas = 10000m, TarifaComision = 0.05m };
        new CommissionPaymentStrategy().Calculate(emp).Amount.Should().Be(500m);
    }

    [Fact]
    public void BasePlusCommission_AddsBaseAndTenPercentBonus()
    {
        var emp = new BaseEmpleadoComision
        {
            VentasBrutas = 5000m, TarifaComision = 0.10m, SalarioBase = 1000m
        };
        new BasePlusCommissionPaymentStrategy().Calculate(emp).Amount.Should().Be(1600m);
    }

    [Fact]
    public void Resolver_PicksCorrectStrategy()
    {
        var resolver = new PaymentStrategyResolver(new IPaymentStrategy[]
        {
            new SalariedPaymentStrategy(),
            new HourlyPaymentStrategy(),
            new CommissionPaymentStrategy(),
            new BasePlusCommissionPaymentStrategy()
        });
        var hourly = new EmpleadoPorHoras { SueldoPorHora = 10, HorasTrabajadas = 45 };
        resolver.Calculate(hourly).Amount.Should().Be(475m);
    }
}
