using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SB.Entities.Empleados;
using SB.Helpers.Exceptions;
using SB.Helpers.Mappers;
using SB.Models.Base;
using SB.Models.Contracts;
using SB.Models.Dtos.RRHH;
using SB.Models.Paginator;
using SB.Services.Interface;
using SB.Services.Strategies;
using System.Security.Claims;

namespace SB.Services.Implementation;

public class EmpleadoService : IEmpleadoService
{
    private readonly IEmployeeRepository _repo;
    private readonly IPaymentStrategyResolver _strategyResolver;
    private readonly IValidator<EmpleadoDtos> _validator;
    private readonly IMapper _mapper;
    private readonly ILogger<EmpleadoService> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public EmpleadoService(
        IEmployeeRepository repo,
        IPaymentStrategyResolver strategyResolver,
        IValidator<EmpleadoDtos> validator,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper,
        ILogger<EmpleadoService> logger)
    {
        _repo = repo;   
        _strategyResolver = strategyResolver;
        _validator = validator;
        _mapper = mapper;
        _logger = logger;
        _httpContextAccessor= httpContextAccessor;
    }
    public async Task<DataCollection<EmpleadoDtos>> GetPaginate(
       PaginatorEmpleadoDto request,
       CancellationToken ct = default)
    {
        _logger.LogInformation(
            "Paginando empleados. Codigo={Codigo} Nombres={Nombres} Apellidos={Apellidos} Dept={Dept} Tipo={Tipo} Activo={Activo} Page={Page} Take={Take}",
            request.Codigo,
            request.Nombres,
            request.Apellidos,
            request.DepartmentoId,
            request.TipoEmpleado,
            request.Activo,
            request.Page,
            request.Take);

        var paged = await _repo.GetPagedAsync(
            page: request.Page,
            take: request.Take,
            orderBy: q => q.OrderByDescending(e => e.Id),
            predicate: e =>
                (!request.Codigo.HasValue || e.Id == request.Codigo.Value)
                && (string.IsNullOrEmpty(request.Nombres) ||
                    EF.Functions.Like(e.Nombres, $"%{request.Nombres}%"))
                && (string.IsNullOrEmpty(request.Apellidos) ||
                    EF.Functions.Like(e.Apellidos, $"%{request.Apellidos}%"))
                && (!request.DepartmentoId.HasValue || e.DepartmentoId == request.DepartmentoId.Value)
                && (!request.TipoEmpleado.HasValue || e.TipoEmpleadoId == request.TipoEmpleado.Value)
                && (!request.Activo.HasValue || e.Activo == request.Activo.Value),
            include: q => q
                .Include(e => e.TipoEmpleado)
                .Include(e => e.Departmento!),
            ct: ct);

        return new DataCollection<EmpleadoDtos>
        {
            Items = paged.Items.Select(MapWithEmpleado).ToList(),
            Total = paged.Total,
            Page = paged.Page,
            Pages = paged.Pages
        };
    }
    public async Task<IEnumerable<EmpleadoDtos>> GetAllAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Consultando todos los empleados");

        var entities = await _repo.GetAllAsync(ct);

        return _mapper.Map<IEnumerable<EmpleadoDtos>>(entities);
    }
    public async Task<EmpleadoDtos?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        _logger.LogInformation("Consultando empleado {EmployeeId}", id);
        var entity = await _repo.GetByIdAsync(id, ct);


        return entity is null ? null : MapWithEmpleado(entity);
    }
    public async Task<EmpleadoDtos> CreateAsync(EmpleadoDtos dto, CancellationToken ct = default)
    {
        await ValidateAsync(dto, ct);

        if (string.IsNullOrWhiteSpace(dto.Nombres))
            throw new AppException("El nombre del empleado es requerido.");

        if (string.IsNullOrWhiteSpace(dto.Apellidos))
            throw new AppException("El apellido del empleado es requerido.");

        if (string.IsNullOrWhiteSpace(dto.NumeroSeguroSocial))
            throw new AppException("El número de seguro social es requerido.");

        if (dto.TipoEmpleadoId <= 0)
            throw new AppException("Debe seleccionar un tipo de empleado válido.");

        if (dto.DepartamentoId <= 0)
            throw new AppException("Debe seleccionar un departamento válido.");

        if (await _repo.ExistsBySsnAsync(dto.NumeroSeguroSocial, null, ct))
            throw new AppException(
                $"Ya existe un empleado con número de seguro social '{dto.NumeroSeguroSocial}'.");

        ValidarCamposPorTipo(dto);

        var entity = EmpleadoFactory.CreateOrUpdateFromDto(dto);

        var usuarioId = _httpContextAccessor.HttpContext?.User
            ?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "SYSTEM";

        entity.FechaRegistra = DateTimeOffset.UtcNow;
        entity.UsuarioRegistra = usuarioId;
        entity.Activo = true;
        entity.Borrado = false;

        await _repo.AddAsync(entity, ct);
        await _repo.SaveChangesAsync(ct);

        _logger.LogInformation(
            "Empleado creado: {Id} ({Tipo}) por usuario {UsuarioId}",
            entity.Id,
            entity.TipoCodigo,
            usuarioId);

        var created = await _repo.GetByIdAsync(entity.Id, ct);
        return MapWithEmpleado(created!);
    }

    private static void ValidarCamposPorTipo(EmpleadoDtos dto)
    {
        switch (dto.TipoEmpleadoId)
        {
            case 1: // Asalariado
                if ( dto.SalarioSemanal <= 0)
                    throw new AppException("El salario semanal es requerido para empleados asalariados.");
                break;

            case 2: // Por horas
                if ( dto.SueldoPorHora <= 0)
                    throw new AppException("El sueldo por hora es requerido para empleados por horas.");

                if ( dto.HorasTrabajadas <= 0)
                    throw new AppException("Las horas trabajadas son requeridas para empleados por horas.");
                break;

            case 3: // Comisión
                if ( dto.VentasBrutas <= 0)
                    throw new AppException("Las ventas brutas son requeridas para empleados por comisión.");

                if ( dto.TarifaComision <= 0)
                    throw new AppException("La tarifa de comisión es requerida para empleados por comisión.");
                break;

            case 4: // Asalariado por comisión
                if ( dto.SalarioBase <= 0)
                    throw new AppException("El salario base es requerido para empleados asalariados por comisión.");

                if ( dto.VentasBrutas <= 0)
                    throw new AppException("Las ventas brutas son requeridas para empleados asalariados por comisión.");

                if ( dto.TarifaComision <= 0)
                    throw new AppException("La tarifa de comisión es requerida para empleados asalariados por comisión.");
                break;

            default:
                throw new AppException("Tipo de empleado no válido.");
        }
    }
  
    public async Task<EmpleadoDtos> UpdateAsync(int id, EmpleadoDtos dto, CancellationToken ct = default)
    {
        await ValidateAsync(dto, ct);

        if (string.IsNullOrWhiteSpace(dto.Nombres))
            throw new AppException("El nombre del empleado es requerido.");

        if (string.IsNullOrWhiteSpace(dto.Apellidos))
            throw new AppException("El apellido del empleado es requerido.");

        if (string.IsNullOrWhiteSpace(dto.NumeroSeguroSocial))
            throw new AppException("El número de seguro social es requerido.");

        if (dto.TipoEmpleadoId <= 0)
            throw new AppException("Debe seleccionar un tipo de empleado válido.");

        if (dto.DepartamentoId <= 0)
            throw new AppException("Debe seleccionar un departamento válido.");

        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Empleado", id);

        if (entity.TipoCodigo != dto.TipoEmpleadoCodigo)
            throw new AppException("No se puede cambiar el tipo de un empleado existente.");
        if (await _repo.ExistsBySsnAsync(dto.NumeroSeguroSocial, id, ct))
            throw new AppException($"Otro empleado ya tiene el número seguro social '{dto.NumeroSeguroSocial}'.");

        var usuarioId = _httpContextAccessor.HttpContext?.User
        ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;

        EmpleadoFactory.ApplyChanges(entity, dto);

        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);

        _logger.LogInformation("Empleado actualizado: {Id}", id);
        var updated = await _repo.GetByIdAsync(id, ct);
        return MapWithEmpleado(updated!);
    }

    public async Task DeactivateAsync(int id, CancellationToken ct = default)
    {
        if (id <= 0)
            throw new AppException("id debe seer mayor a 0.");

        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Empleado", id);

        var usuarioId = _httpContextAccessor.HttpContext?.User
        ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;
        entity.Activo = false;

        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);
        _logger.LogInformation("Empleado inactivado: {Id}", id);
    }
    public async Task ActivateAsync(int id, CancellationToken ct = default)
    {
        if (id <= 0)
            throw new AppException("id debe seer mayor a 0.");

        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Empleado", id);

        var usuarioId = _httpContextAccessor.HttpContext?.User
      ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;
        entity.Activo = true;

        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);
        _logger.LogInformation("Empleado activado: {Id}", id);
    }
    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        if (id <= 0)
            throw new AppException("id debe seer mayor a 0.");

        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Empleado", id);

        var usuarioId = _httpContextAccessor.HttpContext?.User
        ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;
        entity.Borrado = true;
        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);
        _logger.LogInformation("Empleado delete: {Id}", id);
    }
    private async Task ValidateAsync(EmpleadoDtos dto, CancellationToken ct)
    {
        var result = await _validator.ValidateAsync(dto, ct);
        if (!result.IsValid)
        {
            var errors = result.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
            throw new Helpers.Exceptions.ValidationException(errors);
        }
    }

    private EmpleadoDtos MapWithEmpleado(Empleado e)
    {
        var dto = _mapper.Map<EmpleadoDtos>(e);
        dto.PagoSemanal = _strategyResolver.Calculate(e).Amount;
        return dto;
    }
}
