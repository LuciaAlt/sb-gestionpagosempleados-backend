using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SB.Entities.Seguridad;
using SB.Helpers.Exceptions;
using SB.Helpers.Mappers;
using SB.Models.Base;
using SB.Models.Contracts;
using SB.Models.Dtos.Seguridad;
using SB.Models.Paginator;
using SB.Services.Interface;
using System.Security.Claims;

namespace SB.Services.Implementation;
public class UsuarioService : IUsuariosService
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<UsuarioService> _logger;
    private readonly IValidator<UsuarioDto> _validator;
    private readonly IValidator<RegistrarUsuarioDto> _registerValidator;
    private readonly IPasswordHasher _hasher;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsuarioService(IUserRepository repo,
        IMapper mapper,
         IPasswordHasher hasher,
         IHttpContextAccessor httpContextAccessor,
         ILogger<UsuarioService> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
        _hasher = hasher;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<DataCollection<UsuarioDto>> GetPaginate(
        PaginatorUserDto request,
        CancellationToken ct = default)
    {
        _logger.LogInformation(
            "Paginando usuarios. Username={U} RoleId={R} Activo={A} Page={P} Take={T}",
            request.NombreUsuario,
            request.RoleId,
            request.Activo,
            request.Page,
            request.Take);

        var paged = await _repo.GetPagedAsync(
            page: request.Page,
            take: request.Take,
            orderBy: q => q.OrderBy(u => u.NombreUsuario),
            predicate: u =>
                (string.IsNullOrEmpty(request.NombreUsuario) ||
                    EF.Functions.Like(u.NombreUsuario, $"%{request.NombreUsuario}%"))
                && (string.IsNullOrEmpty(request.Nombres) ||
                    EF.Functions.Like(u.Nombres, $"%{request.Nombres}%"))
                && (string.IsNullOrEmpty(request.Apellidos) ||
                    EF.Functions.Like(u.Apellidos, $"%{request.Apellidos}%"))
                && (!request.Id.HasValue || u.Id == request.Id.Value)
                && (!request.RoleId.HasValue || u.RolId == request.RoleId.Value)
                && (!request.Activo.HasValue || u.Activo == request.Activo.Value)
                && (!request.Bloqueado.HasValue || u.Bloqueado == request.Bloqueado.Value),
            include: q => q.Include(u => u.Rol!),
            ct: ct);

        return new DataCollection<UsuarioDto>
        {
            Items = _mapper.Map<IEnumerable<UsuarioDto>>(paged.Items),
            Total = paged.Total,
            Page = paged.Page,
            Pages = paged.Pages
        };
    }
    public async Task<IEnumerable<UsuarioDto>> GetAllAsync(CancellationToken ct = default)
    {
        _logger.LogInformation("Consultando todos los usuarios");

        var entities = await _repo.GetAllAsync(ct);

        return _mapper.Map<IEnumerable<UsuarioDto>>(entities);
    }
    public async Task<UsuarioDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        _logger.LogInformation("Consultando usuario {UsuarioId}", id);
        var entity = await _repo.GetByIdAsync(id, ct);
        return entity is null ? null : MapWithPayment(entity);
    }

    private static async Task ValidateAsync<T>(IValidator<T> validator, T instance, CancellationToken ct)
    {
        var result = await validator.ValidateAsync(instance, ct);
        if (!result.IsValid)
        {
            var errors = result.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
            throw new Helpers.Exceptions.ValidationException(errors);
        }
    }
    public async Task<UsuarioDto> CreateAsync(UsuarioDto request, CancellationToken ct = default)
    {
        await ValidateAsync(_validator, request, ct);

        if(string.IsNullOrWhiteSpace(request.Nombres))
            throw new AppException("El nombre del usuario es requerido.");

        if (string.IsNullOrWhiteSpace(request.Apellidos))
            throw new AppException("El apellido del usuario es requerido.");

        if (string.IsNullOrWhiteSpace(request.NombreUsuario))
            throw new AppException("El nombre del accesso del usuario es requerido.");

        if (string.IsNullOrWhiteSpace(request.Correo))
            throw new AppException("El correo del usuario es requerido.");

        if (request.RolId <= 0)
            throw new AppException("Debe seleccionar el rol del usuario.");

        if (await _repo.ExistsByUsernameAsync(request.NombreUsuario, ct))
            throw new AppException($"Ya existe un Usuario con NombreUsuario '{request.NombreUsuario}'.");

        if (await _repo.ExistsByEmailAsync(request.NombreUsuario, ct))
            throw new AppException($"Ya existe un Usuario con este correo '{request.Correo}'.");

        var usuarioId = _httpContextAccessor.HttpContext?.User
         ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var entity = UsuarioFactory.CreateFromDto(request);

        entity.FechaRegistra = DateTimeOffset.Now;
        entity.UsuarioRegistra = usuarioId;
        entity.FechaCambioContrasena = DateTime.Now.AddDays(3);
        entity.HashContrasena = _hasher.Hash(request.HashContrasena);

        await _repo.AddAsync(entity, ct);
        await _repo.SaveChangesAsync(ct);

        _logger.LogInformation("Usuario creado: {Id} ", entity.Id);
        var created = await _repo.GetByIdAsync(entity.Id, ct);
        return MapWithPayment(created!);
    }

    public async Task<UsuarioDto> UpdateAsync(int id, UsuarioDto dto, CancellationToken ct = default)
    {
        await ValidateAsync(dto, ct);

        if (string.IsNullOrWhiteSpace(dto.Nombres))
            throw new AppException("El nombre del usuario es requerido.");

        if (string.IsNullOrWhiteSpace(dto.Apellidos))
            throw new AppException("El apellido del usuario es requerido.");

        if (string.IsNullOrWhiteSpace(dto.NombreUsuario))
            throw new AppException("El nombre del accesso del usuario es requerido.");

        if (string.IsNullOrWhiteSpace(dto.Correo))
            throw new AppException("El correo del usuario es requerido.");
        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Usuario", id);

        UsuarioFactory.ApplyChanges(entity, dto);

        var usuarioId = _httpContextAccessor.HttpContext?.User
         ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;

        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);

        _logger.LogInformation("Usuario actualizado: {Id}", id);
        var updated = await _repo.GetByIdAsync(id, ct);
        return MapWithPayment(updated!);
    }

    public async Task DeactivateAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Usuario", id);

        var usuarioId = _httpContextAccessor.HttpContext?.User
       ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;
        entity.Activo = false;
        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);
        _logger.LogInformation("Usuario inactivado: {Id}", id);
    }
    public async Task ActivateAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Usuario", id);

        var usuarioId = _httpContextAccessor.HttpContext?.User
       ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;
        entity.Activo = true;

        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);
        _logger.LogInformation("Usuario activado: {Id}", id);
    }
    public async Task BlockAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Usuario", id);

        var usuarioId = _httpContextAccessor.HttpContext?.User
       ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;
        entity.Bloqueado = true;

        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);
        _logger.LogInformation("Usuario block: {Id}", id);
    }
    public async Task UnlockAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Usuario", id);

        var usuarioId = _httpContextAccessor.HttpContext?.User
       ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;
        entity.Bloqueado = false;

        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);
        _logger.LogInformation("Usuario unblock: {Id}", id);
    }
    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repo.GetByIdAsync(id, ct) ?? throw new NotFoundException("Usuario", id);

        var usuarioId = _httpContextAccessor.HttpContext?.User
        ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        entity.FechaModifica = DateTimeOffset.Now;
        entity.UsuarioModifica = usuarioId;
        entity.Borrado = true;
        _repo.Update(entity);
        await _repo.SaveChangesAsync(ct);
        _logger.LogInformation("Usuario delete: {Id}", id);
    }
    private async Task ValidateAsync(UsuarioDto dto, CancellationToken ct)
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

    private UsuarioDto MapWithPayment(Usuario e)
    {
        var dto = _mapper.Map<UsuarioDto>(e);
        return dto;
    }
}
