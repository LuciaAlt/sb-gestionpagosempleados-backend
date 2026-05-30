using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Seguridad;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Seguridad;

public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
{
    public void Configure(EntityTypeBuilder<Auditoria> builder)
    {
        builder.ToTable("Auditoria", Constants.Schemas.Seguridad);
        builder.HasKey(a => a.Id);
        builder.Property(a => a.UsuarioRegistra).HasMaxLength(50);
        builder.Property(a => a.Accion).IsRequired().HasMaxLength(40);
        builder.Property(a => a.Entidad).IsRequired().HasMaxLength(80);
        builder.Property(a => a.Detalle).HasMaxLength(2000);
        builder.Property(a => a.Ip).HasMaxLength(60);

        // Índices útiles para consultas de bitácora
        builder.HasIndex(a => a.Fecha);
        builder.HasIndex(a => a.UsuarioRegistra);
        builder.HasIndex(a => new { a.Entidad, a.EntidadId });
    }
}
