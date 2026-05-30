using Microsoft.EntityFrameworkCore;
using SB.Entities.Empleados;
using SB.Entities.Seguridad;

namespace SB.Repositories.Context;

public class SBDbContext : DbContext
{
    public SBDbContext(DbContextOptions<SBDbContext> options) : base(options) { }

    // Esquema Empleados
    public DbSet<Empleado> Employees => Set<Empleado>();
    public DbSet<EmpleadoAsalariado> SalariedEmployees => Set<EmpleadoAsalariado>();
    public DbSet<EmpleadoPorHoras> HourlyEmployees => Set<EmpleadoPorHoras>();
    public DbSet<EmpleadoComision> CommissionEmployees => Set<EmpleadoComision>();
    public DbSet<BaseEmpleadoComision> BasePlusCommissionEmployees => Set<BaseEmpleadoComision>();
    public DbSet<Departamento> Departments => Set<Departamento>();
    public DbSet<TipoEmpleado> EmployeeTypes => Set<TipoEmpleado>();

    // Esquema Seguridad
    public DbSet<Usuario> Users => Set<Usuario>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Modulo> Modules => Set<Modulo>();
    public DbSet<Permiso> Permissions => Set<Permiso>();
    public DbSet<RolPermiso> RolePermissions => Set<RolPermiso>();
    public DbSet<Auditoria> AuditLogs => Set<Auditoria>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfigurationsFromAssembly(typeof(SBDbContext).Assembly);
        base.OnModelCreating(mb);
    }
}
