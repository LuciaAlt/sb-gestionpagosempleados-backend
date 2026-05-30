using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Seguridad;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Seguridad;

public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.ToTable("Modulo", Constants.Schemas.Seguridad);
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Codigo).IsRequired().HasMaxLength(40);
        builder.Property(m => m.Nombre).IsRequired().HasMaxLength(80);
        builder.Property(m => m.Icono).HasMaxLength(120);
        builder.Property(m => m.UsuarioRegistra).IsRequired().HasMaxLength(50);
        builder.Property(m => m.UsuarioModifica).HasMaxLength(50);
        builder.HasIndex(m => m.Codigo).IsUnique();

        builder.HasQueryFilter(m => !m.Borrado);

        var seed = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var sys = Constants.System.SystemUser;
        builder.HasData(
            new Modulo { Id = 1, Codigo = "001", Nombre = "Gestión de Empleados", Icono = "ti-users",       Orden = 1, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Modulo { Id = 2, Codigo = "002",  Nombre = "Usuarios del Sistema", Icono = "ti-user-shield", Orden = 2, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Modulo { Id = 3, Codigo = "003", Nombre = "Reportes", Icono = "ti-report", Orden = 3, UsuarioRegistra = sys, FechaRegistra = seed, Activo = true }
        );
    }
}
