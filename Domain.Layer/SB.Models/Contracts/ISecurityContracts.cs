using SB.Entities.Seguridad;

namespace SB.Models.Contracts;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string hash);
}

public interface IJwtTokenGenerator
{
    (string Token, DateTimeOffset ExpiresAt) Generate(Usuario user, IEnumerable<string> permisos);
}

/// <summary>
/// Provee el usuario actual de la request en curso. Lo consume el AuditableInterceptor
/// para llenar UsuarioRegistra/UsuarioModifica automáticamente.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>Username del usuario autenticado, o "SYSTEM"/"ANONIMO" si no hay sesión.</summary>
    string Username { get; }

    /// <summary>Id del usuario autenticado.</summary>
    int? UserId { get; }

    /// <summary>IP de origen de la request.</summary>
    string? Ip { get; }
}
