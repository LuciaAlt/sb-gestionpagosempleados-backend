using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Seguridad;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Seguridad;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario", Constants.Schemas.Seguridad);
        builder.HasKey(u => u.Id);
       
        builder.Property(u => u.NombreUsuario).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Nombres).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Apellidos).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Correo).IsRequired().HasMaxLength(100);
        builder.Property(u => u.HashContrasena).IsRequired().HasMaxLength(255);
        builder.Property(u => u.UsuarioRegistra).IsRequired().HasMaxLength(50);
        builder.Property(u => u.UsuarioModifica).HasMaxLength(50);
        builder.HasIndex(u => u.NombreUsuario).IsUnique();

        builder.HasQueryFilter(u => !u.Borrado);

        builder.HasOne(u => u.Rol)
               .WithMany(r => r.Usuarios)
               .HasForeignKey(u => u.RolId)
               .OnDelete(DeleteBehavior.Restrict);

       
    }
}
