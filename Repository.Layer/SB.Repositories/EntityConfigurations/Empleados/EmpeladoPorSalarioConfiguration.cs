using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Empleados;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Empleados;

public class EmpeladoPorSalarioConfiguration : IEntityTypeConfiguration<EmpleadoAsalariado>
{
    public void Configure(EntityTypeBuilder<EmpleadoAsalariado> builder)
    {
        var seed = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var sys = Constants.System.SystemUser;
        builder.HasData(
            new EmpleadoAsalariado { Id = 1, Nombres = "Carlos",   Apellidos = "Ramírez",   NumeroSeguroSocial = "001-1000001-1", DepartmentoId = 1, TipoEmpleadoId = (int)CodigoTipoEmpleado.Asalariado, SalarioSemanal = 1200.00m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new EmpleadoAsalariado { Id = 2, Nombres = "Patricia", Apellidos = "Núñez",     NumeroSeguroSocial = "001-1000002-2", DepartmentoId = 4, TipoEmpleadoId = (int)CodigoTipoEmpleado.Asalariado, SalarioSemanal = 1850.50m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new EmpleadoAsalariado { Id = 3, Nombres = "Luis", Apellidos = "Hernández", NumeroSeguroSocial = "001-1000003-3", DepartmentoId = 2, TipoEmpleadoId = (int)CodigoTipoEmpleado.Asalariado, SalarioSemanal = 2100.00m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true }
        );
    }
}
