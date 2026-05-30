using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Seguridad;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Seguridad;

public class PermisoConfiguration : IEntityTypeConfiguration<Permiso>
{
    public void Configure(EntityTypeBuilder<Permiso> builder)
    {
        builder.ToTable("Permiso", Constants.Schemas.Seguridad);
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Codigo).IsRequired().HasMaxLength(80);
        builder.Property(p => p.Nombre).IsRequired().HasMaxLength(120);
        builder.Property(p => p.UsuarioRegistra).IsRequired().HasMaxLength(50);
        builder.Property(p => p.UsuarioModifica).HasMaxLength(50);
        builder.HasIndex(p => p.Codigo).IsUnique();

        builder.HasOne(p => p.Modulo)
               .WithMany(m => m.Permisos)
               .HasForeignKey(p => p.ModuloId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(p => !p.Borrado);

        var seed = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var sys = Constants.System.SystemUser;
        builder.HasData(
            // Módulo EMPLEADOS (id=1)
            new Permiso { Id = 1, ModuloId = 1, Codigo = "EMPLEADOS_VER",      Nombre = "Ver empleados",       UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Permiso { Id = 2, ModuloId = 1, Codigo = "EMPLEADOS_CREAR",    Nombre = "Crear empleados",     UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Permiso { Id = 3, ModuloId = 1, Codigo = "EMPLEADOS_EDITAR",   Nombre = "Editar empleados",    UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Permiso { Id = 4, ModuloId = 1, Codigo = "EMPLEADOS_INACTIVAR",Nombre = "Inactivar empleados", UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },

            // Módulo USUARIOS (id=2)
            new Permiso { Id = 7, ModuloId = 2, Codigo = "USUARIOS_VER", Nombre = "Ver usuarios", UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Permiso { Id = 8, ModuloId = 2, Codigo = "USUARIOS_CREAR", Nombre = "Crear usuarios", UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Permiso { Id = 9, ModuloId = 2, Codigo = "AUDITORIA_VER", Nombre = "Ver bitácora", UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },

            // Módulo REPORTES (id=3)
            new Permiso { Id = 5, ModuloId = 3, Codigo = "REPORTES_VER",       Nombre = "Ver reportes",        UsuarioRegistra = sys, FechaRegistra = seed, Activo = true },
            new Permiso { Id = 6, ModuloId = 3, Codigo = "REPORTES_EXPORTAR",  Nombre = "Exportar reportes",   UsuarioRegistra = sys, FechaRegistra = seed, Activo = true }

           
        );
    }
}
