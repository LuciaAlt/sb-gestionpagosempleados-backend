using AutoMapper;
using Microsoft.Extensions.Logging;
using SB.Models.Contracts;
using SB.Models.Dtos.RRHH;
using SB.Models.Dtos.Seguridad;
using SB.Services.Interface;


namespace SB.Services.Implementation;

public class CatalogService : ICatalogosService
{
    private readonly IDepartmentRepository _deptRepo;
    private readonly IEmployeeTypeRepository _typeRepo;
    private readonly IModuleRepository _moduleRepo;
    private readonly IMapper _mapper;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(IDepartmentRepository deptRepo, IEmployeeTypeRepository typeRepo,
        IModuleRepository moduleRepo, IMapper mapper, ILogger<CatalogService> logger)
    {
        _deptRepo = deptRepo;
        _typeRepo = typeRepo;
        _moduleRepo = moduleRepo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Listando departamentos");
        var items = (await _deptRepo.GetAllAsync(ct)).Where(d => d.Activo).OrderBy(d => d.Nombre);
        return _mapper.Map<IEnumerable<DepartmentDto>>(items);
    }

    public async Task<IEnumerable<TipoEmpleadoDto>> GetEmployeeTypesAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Listando tipos de empleado");
        var items = (await _typeRepo.GetAllAsync(ct)).Where(t => t.Activo).OrderBy(t => t.Id);
        return _mapper.Map<IEnumerable<TipoEmpleadoDto>>(items);
    }

    public async Task<IEnumerable<ModuleDto>> GetModulesAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Listando módulos");
        var items = (await _moduleRepo.GetAllAsync(ct)).Where(m => m.Activo).OrderBy(m => m.Orden);
        return _mapper.Map<IEnumerable<ModuleDto>>(items);
    }
}



