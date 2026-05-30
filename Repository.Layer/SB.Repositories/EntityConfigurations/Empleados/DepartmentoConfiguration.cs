using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Empleados;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Empleados;

public class DepartmentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento", Constants.Schemas.RRHH);
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Nombre).IsRequired().HasMaxLength(150);
        builder.Property(d => d.Descripcion).HasMaxLength(250);
        builder.Property(d => d.UsuarioRegistra).IsRequired().HasMaxLength(50);
        builder.Property(d => d.UsuarioModifica).HasMaxLength(50);
        builder.HasIndex(d => d.Nombre).IsUnique();

        // Filtro global: nunca devolver registros borrados
        builder.HasQueryFilter(d => !d.Borrado);

        var seed = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        builder.HasData(
            new Departamento { Id = 1, Nombre = "Recursos Humanos", Descripcion = "RRHH",         UsuarioRegistra = Constants.System.SystemUser, FechaRegistra = seed, Activo = true },
            new Departamento { Id = 2, Nombre = "Tecnología",       Descripcion = "TI",           UsuarioRegistra = Constants.System.SystemUser, FechaRegistra = seed, Activo = true },
            new Departamento { Id = 3, Nombre = "Ventas",           Descripcion = "Comercial",    UsuarioRegistra = Constants.System.SystemUser, FechaRegistra = seed, Activo = true },
            new Departamento { Id = 4, Nombre = "Finanzas",         Descripcion = "Contabilidad", UsuarioRegistra = Constants.System.SystemUser, FechaRegistra = seed, Activo = true },
            new Departamento { Id = 5, Nombre = "Operaciones",      Descripcion = "Operaciones",  UsuarioRegistra = Constants.System.SystemUser, FechaRegistra = seed, Activo = true }
        );
    }
}
