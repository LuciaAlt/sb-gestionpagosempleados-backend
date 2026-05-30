using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Entities.Empleados;
using SB.Models.Helpers;

namespace SB.Repositories.EntityConfigurations.Empleados;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleado", Constants.Schemas.RRHH);
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nombres).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Apellidos).IsRequired().HasMaxLength(100);
        builder.Property(e => e.NumeroSeguroSocial).IsRequired().HasMaxLength(20);
        builder.Property(e => e.UsuarioRegistra).IsRequired().HasMaxLength(50);
        builder.Property(e => e.UsuarioModifica).HasMaxLength(50);
        builder.HasIndex(e => e.NumeroSeguroSocial).IsUnique();

        builder.HasQueryFilter(e => !e.Borrado);

        builder.HasOne(e => e.Departmento)
               .WithMany(d => d.Empleados)
               .HasForeignKey(e => e.DepartmentoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.TipoEmpleado)
               .WithMany(t => t.Empleados)
               .HasForeignKey(e => e.TipoEmpleadoId)
               .OnDelete(DeleteBehavior.Restrict);

        // TPH: discriminador = EmployeeTypeId (la misma columna que la FK)
        builder.HasDiscriminator(e => e.TipoEmpleadoId)
            .HasValue<EmpleadoAsalariado>((int)CodigoTipoEmpleado.Asalariado)
            .HasValue<Entities.Empleados.EmpleadoPorHoras>((int)CodigoTipoEmpleado.PorHoras)
            .HasValue<EmpleadoComision>((int)CodigoTipoEmpleado.PorComision)
            .HasValue<BaseEmpleadoComision>((int)CodigoTipoEmpleado.AsalariadoPorComision);

        builder.Property<decimal>("SalarioSemanal").HasColumnType("decimal(18,2)");
        builder.Property<decimal>("SueldoPorHora").HasColumnType("decimal(18,2)");
        builder.Property<decimal>("HorasTrabajadas").HasColumnType("decimal(18,2)");
        builder.Property<decimal>("VentasBrutas").HasColumnType("decimal(18,2)");
        builder.Property<decimal>("TarifaComision").HasColumnType("decimal(5,4)");
        builder.Property<decimal>("SalarioBase").HasColumnType("decimal(18,2)");
    }
}

