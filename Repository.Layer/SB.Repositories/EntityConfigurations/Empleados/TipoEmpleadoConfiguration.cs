using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Empleados;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Empleados;

public class TipoEmpleadoConfiguration : IEntityTypeConfiguration<TipoEmpleado>
{
    public void Configure(EntityTypeBuilder<TipoEmpleado> builder)
    {
        builder.ToTable("TipoEmpleado", Constants.Schemas.RRHH);
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Codigo).IsRequired().HasMaxLength(60);
        builder.Property(t => t.Nombre).IsRequired().HasMaxLength(80);
        builder.Property(t => t.Descripcion).HasMaxLength(250);
        builder.Property(t => t.UsuarioRegistra).IsRequired().HasMaxLength(50);
        builder.Property(t => t.UsuarioModifica).HasMaxLength(50);
        builder.HasIndex(t => t.Codigo).IsUnique();

        builder.HasQueryFilter(t => !t.Borrado);

        var seed = DateTimeOffset.Now;
        var sys = Constants.System.SystemUser;
        builder.HasData(
            new TipoEmpleado { Id = 1, Codigo = "001",         Nombre = "Empleado Asalariado",              Descripcion = "Pago semanal fijo.",                    UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new TipoEmpleado { Id = 2, Codigo = "002",           Nombre = "Empleado por Horas",               Descripcion = "Horas regulares + extras al 1.5×.",     UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new TipoEmpleado { Id = 3, Codigo = "003",        Nombre = "Empleado por Comisión",            Descripcion = "Ventas brutas × tarifa.",               UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new TipoEmpleado { Id = 4, Codigo = "004", Nombre = "Empleado Asalariado por Comisión", Descripcion = "Comisión + base + 10% del base.",       UsuarioRegistra = sys, FechaRegistra = seed, Activo = true }
        );
    }
}
