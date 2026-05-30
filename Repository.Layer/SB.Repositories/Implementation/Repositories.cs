using Microsoft.EntityFrameworkCore;
using SB.Entities.Empleados;
using SB.Entities.Seguridad;
using SB.Models.Contracts;
using SB.Models.Helpers;
using SB.Repositories.Context;
using System.Security.Cryptography;

namespace SB.Repositories.Implementation;
public class EmployeeRepository : RepositoryBase<Empleado>, IEmployeeRepository
{
    public EmployeeRepository(SBDbContext context) : base(context) { }

    public override Task<Empleado?> GetByIdAsync(int id, CancellationToken ct = default)
        => _context.Empleado
                   .Include(e => e.Departmento)
                   .Include(e => e.TipoEmpleado)
                   .FirstOrDefaultAsync(e => e.Id == id, ct);

    public override async Task<IEnumerable<Empleado>> GetAllAsync(CancellationToken ct = default)
        => await _context.Empleado.AsNoTracking()
                                   .Include(e => e.Departmento)
                                   .Include(e => e.TipoEmpleado)
                                   .ToListAsync(ct);

    public Task<bool> ExistsBySsnAsync(string ssn, int? excludeId = null, CancellationToken ct = default)
        => _context.Empleado.AnyAsync(
            e => e.NumeroSeguroSocial == ssn && (!excludeId.HasValue || e.Id != excludeId.Value),
            ct);
}
public class DepartmentRepository : RepositoryBase<Departamento>, IDepartmentRepository
{
    public DepartmentRepository(SBDbContext context) : base(context) { }
}

public class EmployeeTypeRepository : RepositoryBase<TipoEmpleado>, IEmployeeTypeRepository
{
    public EmployeeTypeRepository(SBDbContext context) : base(context) { }
}

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(SBDbContext context) : base(context) { }
}

public class ModuleRepository : RepositoryBase<Modulo>, IModuleRepository
{
    public ModuleRepository(SBDbContext context) : base(context) { }
}

public class PermissionRepository : RepositoryBase<Permiso>, IPermissionRepository
{
    public PermissionRepository(SBDbContext context) : base(context) { }

    public async Task<IEnumerable<string>> GetCodesByRoleIdAsync(int roleId, CancellationToken ct = default)
        => await _context.RolPermiso
            .Where(rp => rp.RolId == roleId && rp.Permiso != null && rp.Permiso.Activo)
            .Select(rp => rp.Permiso!.Codigo)
            .ToListAsync(ct);
}

public class UserRepository : RepositoryBase<Usuario>, IUserRepository
{
    public UserRepository(SBDbContext context) : base(context) { }

    public override Task<Usuario?> GetByIdAsync(int id, CancellationToken ct = default)
        => _context.Usuario.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Id == id, ct);

    public Task<Usuario?> GetByUsernameAsync(string username, CancellationToken ct = default)
        => _context.Usuario.Include(u => u.Rol).FirstOrDefaultAsync(u => u.NombreUsuario == username, ct);

    public Task<bool> ExistsByUserAsync(string username, CancellationToken ct = default)
        => _context.Usuario.AnyAsync(u => u.NombreUsuario == username, ct);

    public Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct = default)
       => _context.Usuario.AnyAsync(u => u.NombreUsuario == username, ct);

    public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default)
      => _context.Usuario.AnyAsync(u => u.Correo == email, ct);
   
}

public class AuditLogRepository : RepositoryBase<Auditoria>, IAuditLogRepository
{
    public AuditLogRepository(SBDbContext context) : base(context) { }

    public async Task LogAsync(string accion, string? usuario, string entidad, int? entidadId = null,
        string? detalle = null, string? ip = null, CancellationToken ct = default)
    {
        // Inserción directa sin pasar por el interceptor (la entidad AuditLog
        // no hereda de EntityAuditableBase para evitar recursión).
        _context.Auditoria.Add(new Auditoria
        {
            UsuarioRegistra = usuario ?? Constants.System.Anonimo,
            Accion = accion,
            Entidad = entidad,
            EntidadId = entidadId,
            Detalle = detalle,
            Ip = ip,
            Fecha = DateTimeOffset.Now
        });
        await _context.SaveChangesAsync(ct);
    }
}
