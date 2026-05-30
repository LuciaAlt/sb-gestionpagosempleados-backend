using SB.Entities.Empleados;
using SB.Entities.Seguridad;

namespace SB.Models.Contracts;

public interface IEmployeeRepository : IRepositoryBase<Empleado>
{
    Task<bool> ExistsBySsnAsync(string ssn, int? excludeId = null, CancellationToken ct = default);
}

public interface IDepartmentRepository : IRepositoryBase<Departamento> { }

public interface IEmployeeTypeRepository : IRepositoryBase<TipoEmpleado> { }

public interface IRoleRepository : IRepositoryBase<Role> { }

public interface IModuleRepository : IRepositoryBase<Modulo> { }

public interface IPermissionRepository : IRepositoryBase<Permiso>
{
    /// <summary>Lista los códigos de permisos asignados a un rol.</summary>
    Task<IEnumerable<string>> GetCodesByRoleIdAsync(int roleId, CancellationToken ct = default);
}

public interface IUserRepository : IRepositoryBase<Usuario>
{
    Task<Usuario?> GetByUsernameAsync(string username, CancellationToken ct = default);
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct = default);
    Task<bool> ExistsByUserAsync(string username, CancellationToken ct = default);
    Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default);
}

public interface IAuditLogRepository : IRepositoryBase<Auditoria>
{
    /// <summary>Inserta un registro de auditoría manual (LOGIN, LOGOUT, etc.).</summary>
    Task LogAsync(string accion, string? usuario, string entidad, int? entidadId = null, string? detalle = null, string? ip = null, CancellationToken ct = default);
}
