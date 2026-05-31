using FluentAssertions;
using SB.Entities.Empleados;
using SB.Models.Dtos.RRHH;
using SB.Repositories.Validators;
using Xunit;

namespace SB.Tests.Validators;

public class EmployeeDtoValidatorTests
{
    private readonly EmpleadoDtoValidator _validator = new();

    [Fact]
    public void Salaried_RequiresSalarioSemanal()
    {
        var dto = new EmpleadoDtos
        {
            Nombres = "Ana", Apellidos = "Pérez",
            NumeroSeguroSocial = "001", DepartamentoId = 1,
            TipoEmpleadoCodigo = CodigoTipoEmpleado.Asalariado
        };
        _validator.Validate(dto).IsValid.Should().BeFalse();
    }

    [Fact]
    public void Hourly_RejectsMoreThan168Hours()
    {
        var dto = new EmpleadoDtos
        {
            Nombres = "Juan", Apellidos = "G", NumeroSeguroSocial = "002",
            DepartamentoId = 1, TipoEmpleadoCodigo = CodigoTipoEmpleado.PorHoras,
            SueldoPorHora = 10, HorasTrabajadas = 200
        };
        _validator.Validate(dto).IsValid.Should().BeFalse();
    }

    [Fact]
    public void BasePlusCommission_FullyValid()
    {
        var dto = new EmpleadoDtos
        {
            Nombres = "María", Apellidos = "L", NumeroSeguroSocial = "003",
            DepartamentoId = 1, TipoEmpleadoCodigo = CodigoTipoEmpleado.AsalariadoPorComision,
            VentasBrutas = 5000, TarifaComision = 0.1m, SalarioBase = 1000
        };
        _validator.Validate(dto).IsValid.Should().BeTrue();
    }
}
