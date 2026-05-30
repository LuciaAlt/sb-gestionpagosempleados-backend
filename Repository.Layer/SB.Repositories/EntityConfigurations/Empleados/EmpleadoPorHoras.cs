using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Empleados;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Empleados;

public class EmpleadoPorHoras : IEntityTypeConfiguration<Entities.Empleados.EmpleadoPorHoras>
{
    public void Configure(EntityTypeBuilder<Entities.Empleados.EmpleadoPorHoras> builder)
    {
        var seed = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var sys = Constants.System.SystemUser;
        builder.HasData(
            new Entities.Empleados.EmpleadoPorHoras { Id = 4, Nombres = "Andrés",  Apellidos = "Pérez",    NumeroSeguroSocial = "001-2000004-4", DepartmentoId = 5, TipoEmpleadoId = (int)CodigoTipoEmpleado.PorHoras, SueldoPorHora = 18.50m, HorasTrabajadas = 38.00m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Entities.Empleados.EmpleadoPorHoras { Id = 5, Nombres = "Mariela", Apellidos = "Castillo", NumeroSeguroSocial = "001-2000005-5", DepartmentoId = 5, TipoEmpleadoId = (int)CodigoTipoEmpleado.PorHoras, SueldoPorHora = 22.00m, HorasTrabajadas = 50.00m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Entities.Empleados.EmpleadoPorHoras { Id = 6, Nombres = "Roberto", Apellidos = "Mejía",    NumeroSeguroSocial = "001-2000006-6", DepartmentoId = 2, TipoEmpleadoId = (int)CodigoTipoEmpleado.PorHoras, SueldoPorHora = 25.75m, HorasTrabajadas = 45.00m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true }
        );
    }
}
