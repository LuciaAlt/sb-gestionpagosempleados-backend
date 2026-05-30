using SB.Entities.Seguridad;
using System.Reflection;

namespace SB.Models.Dtos.Auth;

public class LoginRequestDto
{
    /// <example>admin</example>
    public string Usuario { get; set; } = string.Empty;
    /// <example>Admin123!</example>
    public string Password { get; set; } = string.Empty;
}

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string NombreUsuario { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public bool Activo { get; set; } = false;
    public bool Bloqueado { get; set; } = false;
    public string UsuarioId { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public IEnumerable<string> Permisos { get; set; } = Enumerable.Empty<string>();
    public IEnumerable<Modulo> Modulos { get; set; } = Enumerable.Empty<Modulo>();
    public DateTimeOffset ExpiraEn { get; set; }
}

