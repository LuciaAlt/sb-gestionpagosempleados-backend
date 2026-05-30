using Microsoft.EntityFrameworkCore;
using SB.Entities.Empleados;
using SB.Entities.Seguridad;

namespace SB.Repositories.Context;

public class SBDbContext : DbContext
{
    public SBDbContext(DbContextOptions<SBDbContext> options) : base(options) { }

    // Esquema Empleados
    public DbSet<Empleado> Empleado => Set<Empleado>();
    public DbSet<EmpleadoAsalariado> EmpleadoAsalariado => Set<EmpleadoAsalariado>();
    public DbSet<EmpleadoPorHoras> EmpleadoPorHoras => Set<EmpleadoPorHoras>();
    public DbSet<EmpleadoComision> EmpleadoComision => Set<EmpleadoComision>();
    public DbSet<BaseEmpleadoComision> BaseMasEmpleadoComision => Set<BaseEmpleadoComision>();
    public DbSet<Departamento> Departmentos => Set<Departamento>();
    public DbSet<TipoEmpleado> TipoEmpleado => Set<TipoEmpleado>();

    // Esquema Seguridad
    public DbSet<Usuario> Usuario => Set<Usuario>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Modulo> Modulo => Set<Modulo>();
    public DbSet<Permiso> Permiso => Set<Permiso>();
    public DbSet<RolPermiso> RolPermiso => Set<RolPermiso>();
    public DbSet<Auditoria> Auditoria => Set<Auditoria>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfigurationsFromAssembly(typeof(SBDbContext).Assembly);
        base.OnModelCreating(mb);
    }
}
