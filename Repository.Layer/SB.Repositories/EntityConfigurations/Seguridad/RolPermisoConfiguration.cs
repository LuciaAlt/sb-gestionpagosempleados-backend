using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Seguridad;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Seguridad;

public class RolPermisoConfiguration : IEntityTypeConfiguration<RolPermiso>
{
    public void Configure(EntityTypeBuilder<RolPermiso> builder)
    {
        builder.ToTable("RolesPermisos", Constants.Schemas.Seguridad);

        builder.HasKey(rp => rp.Id);

        builder.Property(rp => rp.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(rp => new { rp.RolId, rp.PermisoId })
               .IsUnique();

        builder.Property(rp => rp.UsuarioConcede).IsRequired().HasMaxLength(50);

        builder.HasOne(rp => rp.Rol)
               .WithMany(r => r.RolesPermisos)
               .HasForeignKey(rp => rp.RolId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rp => rp.Permiso)
               .WithMany(p => p.RolePermisos)
               .HasForeignKey(rp => rp.PermisoId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(p => !p.Borrado);

        var seed =  DateTimeOffset.Now;
        var sys = Constants.System.SystemUser;
        // ADMIN: todos los permisos (1..9)
        var adminRows = Enumerable.Range(1, 12).Select(pid =>
            new RolPermiso
            {
                Id = pid,
                RolId = 1,
                PermisoId = pid,
                FechaConcedida = seed,
                UsuarioConcede = sys
            });
        // USUARIO: solo lectura (1=EMPLEADOS_VER, 5=REPORTES_VER, 6=REPORTES_EXPORTAR)
        var userRows = new[] { 1, 5 }.Select((pid, idx) =>
            new RolPermiso
            {
                Id = 13 + idx,
                RolId = 2,
                PermisoId = pid,
                FechaConcedida = seed,
                UsuarioConcede = sys
            });

        builder.HasData(adminRows.Concat(userRows).ToArray());
    }
}
