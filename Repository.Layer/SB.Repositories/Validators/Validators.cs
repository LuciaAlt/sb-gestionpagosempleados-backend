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
        RuleFor(x => x.Nombres)
            .NotEmpty().WithMessage("El nombre del empleado es requerido.")
            .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

        RuleFor(x => x.Apellidos)
            .NotEmpty().WithMessage("El apellido del empleado es requerido.")
            .MaximumLength(50).WithMessage("El apellido no puede exceder los 50 caracteres.");

        RuleFor(x => x.NumeroSeguroSocial)
            .NotEmpty().WithMessage("El número de seguro social es requerido.")
            .MaximumLength(20).WithMessage("El número de seguro social no puede exceder los 20 caracteres.");

        RuleFor(x => x.DepartamentoId)
            .GreaterThan(0)
            .WithMessage("Debe seleccionar un departamento válido.");

        RuleFor(x => x.TipoEmpleadoId)
            .GreaterThan(0)
            .WithMessage("Debe seleccionar un tipo de empleado válido.");

        When(x => x.TipoEmpleadoId == (int)CodigoTipoEmpleado.Asalariado, () =>
        {
            RuleFor(x => x.SalarioSemanal)
                .NotNull().WithMessage("El salario semanal es requerido.")
                .GreaterThan(0).WithMessage("El salario semanal debe ser mayor que cero.");
        });

        When(x => x.TipoEmpleadoId == (int)CodigoTipoEmpleado.PorHoras, () =>
        {
            RuleFor(x => x.SueldoPorHora)
                .NotNull().WithMessage("El sueldo por hora es requerido.")
                .GreaterThan(0).WithMessage("El sueldo por hora debe ser mayor que cero.");

            RuleFor(x => x.HorasTrabajadas)
                .NotNull().WithMessage("Las horas trabajadas son requeridas.")
                .GreaterThanOrEqualTo(0).WithMessage("Las horas trabajadas no pueden ser negativas.")
                .LessThanOrEqualTo(Constants.Validation.HorasMaxSemana)
                .WithMessage($"Las horas trabajadas no pueden exceder {Constants.Validation.HorasMaxSemana}.");
        });

        When(x => x.TipoEmpleadoId == (int)CodigoTipoEmpleado.PorComision, () =>
        {
            RuleFor(x => x.VentasBrutas)
                .NotNull().WithMessage("Las ventas brutas son requeridas.")
                .GreaterThanOrEqualTo(0).WithMessage("Las ventas brutas no pueden ser negativas.");

            RuleFor(x => x.TarifaComision)
                .NotNull().WithMessage("La tarifa de comisión es requerida.")
                .InclusiveBetween(
                    Constants.Validation.TarifaComisionMin,
                    Constants.Validation.TarifaComisionMax)
                .WithMessage($"La tarifa de comisión debe estar entre {Constants.Validation.TarifaComisionMin} y {Constants.Validation.TarifaComisionMax}.");
        });

        When(x => x.TipoEmpleadoId == (int)CodigoTipoEmpleado.AsalariadoPorComision, () =>
        {
            RuleFor(x => x.VentasBrutas)
                .NotNull().WithMessage("Las ventas brutas son requeridas.")
                .GreaterThanOrEqualTo(0).WithMessage("Las ventas brutas no pueden ser negativas.");

            RuleFor(x => x.TarifaComision)
                .NotNull().WithMessage("La tarifa de comisión es requerida.")
                .InclusiveBetween(
                    Constants.Validation.TarifaComisionMin,
                    Constants.Validation.TarifaComisionMax)
                .WithMessage($"La tarifa de comisión debe estar entre {Constants.Validation.TarifaComisionMin} y {Constants.Validation.TarifaComisionMax}.");

            RuleFor(x => x.SalarioBase)
                .NotNull().WithMessage("El salario base es requerido.")
                .GreaterThan(0).WithMessage("El salario base debe ser mayor que cero.");
        });
    }
}

public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestDtoValidator()
    {
        RuleFor(x => x.Usuario)
        .NotEmpty()
        .WithMessage("El usuario es requerido.")
        .MaximumLength(50)
        .WithMessage("El usuario no puede exceder los 50 caracteres.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("La contraseña es requerida.")
            .MinimumLength(6)
            .WithMessage("La contraseña debe tener al menos 6 caracteres.");
    }
}

public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
{
    public UsuarioDtoValidator()
    {
        RuleFor(x => x.NombreUsuario)
        .NotEmpty()
        .WithMessage("El nombre de usuario es requerido.")
        .MaximumLength(50)
        .WithMessage("El nombre de usuario no puede exceder los 50 caracteres.");

        RuleFor(x => x.Nombres)
            .NotEmpty()
            .WithMessage("Los nombres son requeridos.")
            .MaximumLength(100)
            .WithMessage("Los nombres no pueden exceder los 100 caracteres.");

        RuleFor(x => x.Apellidos)
            .NotEmpty()
            .WithMessage("Los apellidos son requeridos.")
            .MaximumLength(100)
            .WithMessage("Los apellidos no pueden exceder los 100 caracteres.");

        RuleFor(x => x.Correo)
            .NotEmpty()
            .WithMessage("El correo electrónico es requerido.")
            .EmailAddress()
            .WithMessage("Debe ingresar un correo electrónico válido.")
            .MaximumLength(100)
            .WithMessage("El correo electrónico no puede exceder los 100 caracteres.");

        RuleFor(x => x.RolId)
            .GreaterThan(0)
            .WithMessage("Debe seleccionar un rol válido.");
    }
}
