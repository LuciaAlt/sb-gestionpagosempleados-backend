using FluentValidation;
using SB.Entities.Empleados;
using SB.Models.Dtos.Auth;
using SB.Models.Dtos.RRHH;
using SB.Models.Dtos.Seguridad;
using SB.Models.Helpers;

namespace SB.Repositories.Validators;

public class EmpleadoDtoValidator : AbstractValidator<EmpleadoDtos>
{
    public EmpleadoDtoValidator()
    {
        RuleFor(x => x.Nombres).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Apellidos).NotEmpty().MaximumLength(50);
        RuleFor(x => x.NumeroSeguroSocial).NotEmpty().MaximumLength(20);
        RuleFor(x => x.DepartamentoId).GreaterThan(0);
        RuleFor(x => x.TipoEmpleadoCodigo).IsInEnum();

        When(x => x.TipoEmpleadoCodigo == CodigoTipoEmpleado.Asalariado, () =>
            RuleFor(x => x.SalarioSemanal).NotNull().GreaterThan(0));

        When(x => x.TipoEmpleadoCodigo == CodigoTipoEmpleado.PorHoras, () =>
        {
            RuleFor(x => x.SueldoPorHora).NotNull().GreaterThan(0);
            RuleFor(x => x.HorasTrabajadas).NotNull()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(Constants.Validation.HorasMaxSemana);
        });

        When(x => x.TipoEmpleadoCodigo == CodigoTipoEmpleado.PorComision, () =>
        {
            RuleFor(x => x.VentasBrutas).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.TarifaComision).NotNull()
                .InclusiveBetween(Constants.Validation.TarifaComisionMin, Constants.Validation.TarifaComisionMax);
        });

        When(x => x.TipoEmpleadoCodigo == CodigoTipoEmpleado.AsalariadoPorComision, () =>
        {
            RuleFor(x => x.VentasBrutas).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.TarifaComision).NotNull()
                .InclusiveBetween(Constants.Validation.TarifaComisionMin, Constants.Validation.TarifaComisionMax);
            RuleFor(x => x.SalarioBase).NotNull().GreaterThan(0);
        });
    }
}

public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(x => x.Usuario).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(4);
    }
}

public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
{
    public UsuarioDtoValidator()
    {
        RuleFor(x => x.NombreUsuario).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Nombres).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Apellidos).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Correo).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(x => x.RolId).GreaterThan(0);
    }
}
