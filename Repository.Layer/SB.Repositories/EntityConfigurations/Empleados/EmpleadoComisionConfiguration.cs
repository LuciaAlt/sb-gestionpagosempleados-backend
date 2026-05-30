using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Empleados;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Empleados;

public class EmpleadoComisionConfiguration : IEntityTypeConfiguration<EmpleadoComision>
{
    public void Configure(EntityTypeBuilder<EmpleadoComision> builder)
    {
        var seed = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var sys = Constants.System.SystemUser;
        builder.HasData(
            new EmpleadoComision { Id = 7, Nombres = "Sandra", Apellidos = "Reyes",   NumeroSeguroSocial = "001-3000007-7", DepartmentoId = 3, TipoEmpleadoId = (int)CodigoTipoEmpleado.PorComision, VentasBrutas = 12000.00m, TarifaComision = 0.05m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true  },
            new EmpleadoComision { Id = 8, Nombres = "Jorge",  Apellidos = "Tavárez", NumeroSeguroSocial = "001-3000008-8", DepartmentoId = 3, TipoEmpleadoId = (int)CodigoTipoEmpleado.PorComision, VentasBrutas = 25500.00m, TarifaComision = 0.07m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true  },
            new EmpleadoComision { Id = 9, Nombres = "Isabel", Apellidos = "Marte",   NumeroSeguroSocial = "001-3000009-9", DepartmentoId = 3, TipoEmpleadoId = (int)CodigoTipoEmpleado.PorComision, VentasBrutas =  8750.00m, TarifaComision = 0.06m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = false }
        );
    }
}
