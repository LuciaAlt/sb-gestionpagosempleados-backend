using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Seguridad;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Seguridad;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", Constants.Schemas.Seguridad);
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Codigo).IsRequired().HasMaxLength(40);
        builder.Property(r => r.Nombre).IsRequired().HasMaxLength(80);
        builder.Property(r => r.UsuarioRegistra).IsRequired().HasMaxLength(50);
        builder.Property(r => r.UsuarioModifica).HasMaxLength(50);
        builder.HasIndex(r => r.Codigo).IsUnique();

        builder.HasQueryFilter(r => !r.Borrado);

        var seed = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var sys = Constants.System.SystemUser;
        builder.HasData(
            new Role { Id = 1, Codigo = Constants.Roles.Admin,   Nombre = "Administrador", UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Role { Id = 2, Codigo = Constants.Roles.Usuario, Nombre = "Usuario",       UsuarioRegistra = sys, FechaRegistra = seed, Activo = true }
        );
    }
}
