using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;
using SB.Entities.Seguridad;
using SB.Helpers.Exceptions;
using SB.Models.Contracts;
using SB.Models.Dtos.Auth;
using SB.Models.Dtos.Seguridad;
using SB.Models.Helpers;
using SB.Services.Interface;

namespace SB.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IPermissionRepository _permRepo;
    private readonly IAuditLogRepository _auditRepo;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtTokenGenerator _tokenGen;
    private readonly ICurrentUserService _currentUser;
    private readonly IValidator<LoginRequestDto> _loginValidator;
    private readonly IValidator<RegistrarUsuarioDto> _registerValidator;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        IUserRepository userRepo,
        IPermissionRepository permRepo,
        IAuditLogRepository auditRepo,
        IPasswordHasher hasher,
        IJwtTokenGenerator tokenGen,
        ICurrentUserService currentUser,
        IValidator<LoginRequestDto> loginValidator,
        IValidator<RegistrarUsuarioDto> registerValidator,
        ILogger<AuthService> logger)
    {
        _userRepo = userRepo;
        _permRepo = permRepo;
        _auditRepo = auditRepo;
        _hasher = hasher;
        _tokenGen = tokenGen;
        _currentUser = currentUser;
        _loginValidator = loginValidator;
        _registerValidator = registerValidator;
        _logger = logger;
    }
    public async Task<LoginResponseDto> LoginAsync(
    LoginRequestDto request,
    CancellationToken ct = default)
    {
        await ValidateAsync(_loginValidator, request, ct);

        var user = await _userRepo.GetByUsernameAsync(request.Usuario, ct);
        var ip = _currentUser.Ip;

        if (user is null)
        {
            await RegistrarLoginFallido(request, "Usuario no existe", ip, ct);
            throw new UnauthorizedException("Usuario o contraseña incorrectos.");
        }

        if (!user.Activo)
        {
            await RegistrarLoginFallido(request, "Usuario inactivo", ip, ct);
            throw new UnauthorizedException("El usuario está inactivo.");
        }

        if (user.Bloqueado)
        {
            await RegistrarLoginFallido(request, "Usuario bloqueado", ip, ct);
            throw new UnauthorizedException("El usuario está bloqueado.");
        }

        if (!_hasher.Verify(request.Password, user.HashContrasena))
        {
            await RegistrarLoginFallido(request, "Contraseña incorrecta", ip, ct);
            throw new UnauthorizedException("Usuario o contraseña incorrectos.");
        }

        var permisos = (await _permRepo.GetCodesByRoleIdAsync(user.RolId, ct)).ToList();

        var (token, expiraen) = _tokenGen.Generate(user, permisos);

        user.UltimoAcceso = DateTimeOffset.UtcNow;
        _userRepo.Update(user);
        await _userRepo.SaveChangesAsync(ct);

        await _auditRepo.LogAsync(
            Constants.AuditActions.Login,
            user.NombreUsuario,
            nameof(Usuario),
            user.Id,
            $"Login exitoso. Rol: {user.Rol?.Codigo}",
            ip,
            ct);

        return new LoginResponseDto
        {
            Token = token,
            UsuarioId = user.Id.ToString(),
            NombreCompleto = $"{user.Nombres} {user.Apellidos}",
            Activo = user.Activo,
            Bloqueado = user.Bloqueado,
            NombreUsuario = user.NombreUsuario,
            Role = user.Rol?.Codigo ?? string.Empty,
            Permisos = permisos,
            Modulos = Enumerable.Empty<Modulo>(),
            ExpiraEn = expiraen
        };
    }
    private async Task RegistrarLoginFallido(
      LoginRequestDto request,
      string motivo,
      string ip,
      CancellationToken ct)
    {
        _logger.LogWarning(
            "Login fallido: {Username} desde {Ip}. Motivo: {Motivo}",
            request.Usuario,
            ip,
            motivo);

        await _auditRepo.LogAsync(
            Constants.AuditActions.LoginFail,
            request.Usuario,
            nameof(Usuario),
            null,
            $"Intento de login fallido para '{request.Usuario}'. Motivo: {motivo}",
            ip,
            ct);
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
}
