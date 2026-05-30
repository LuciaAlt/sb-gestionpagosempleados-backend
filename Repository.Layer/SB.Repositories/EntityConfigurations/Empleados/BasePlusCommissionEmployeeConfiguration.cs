using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Empleados;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Empleados;

public class BasePlusCommissionEmployeeConfiguration : IEntityTypeConfiguration<BaseEmpleadoComision>
{
    public void Configure(EntityTypeBuilder<BaseEmpleadoComision> builder)
    {
        var seed = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var sys = Constants.System.SystemUser;
        builder.HasData(
            new BaseEmpleadoComision { Id = 10, Nombres = "Elena",  Apellidos = "Vásquez", NumeroSeguroSocial = "001-4000010-0", DepartmentoId = 3, TipoEmpleadoId = (int)CodigoTipoEmpleado.AsalariadoPorComision, VentasBrutas = 15000.00m, TarifaComision = 0.08m, SalarioBase = 500.00m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new BaseEmpleadoComision { Id = 11, Nombres = "Daniel", Apellidos = "Sosa",    NumeroSeguroSocial = "001-4000011-1", DepartmentoId = 3, TipoEmpleadoId = (int)CodigoTipoEmpleado.AsalariadoPorComision, VentasBrutas = 22000.00m, TarifaComision = 0.06m, SalarioBase = 800.00m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new BaseEmpleadoComision { Id = 12, Nombres = "Karen", Apellidos = "Polanco", NumeroSeguroSocial = "001-4000012-2", DepartmentoId = 3, TipoEmpleadoId = (int)CodigoTipoEmpleado.AsalariadoPorComision, VentasBrutas =  9500.00m, TarifaComision = 0.10m, SalarioBase = 600.00m, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true }
        );
    }
}
