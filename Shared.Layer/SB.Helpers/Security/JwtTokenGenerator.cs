using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SB.Entities.Seguridad;
using SB.Models.Contracts;

namespace SB.Helpers.Security;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _opt;
    public JwtTokenGenerator(IOptions<JwtOptions> opt) => _opt = opt.Value;
    
    public (string Token, DateTimeOffset ExpiresAt) Generate(Usuario user, IEnumerable<string> permisos)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_opt.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        
            new Claim(ClaimTypes.Name, user.NombreUsuario),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.NombreUsuario),
        
            new Claim("NombreCompleto", $"{user.Nombres} {user.Apellidos}"),
            new Claim("Activo", user.Activo.ToString().ToLowerInvariant()),
            new Claim("Bloqueado", user.Bloqueado.ToString().ToLowerInvariant()),
        
            new Claim(JwtRegisteredClaimNames.Email, user.Correo),
            new Claim(ClaimTypes.Role, user.Rol?.Codigo ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Permisos como claims separados — el frontend puede leerlos para mostrar/ocultar botones
        foreach (var p in permisos.Distinct())
            claims.Add(new Claim("Permiso", p));

        var expiresAt = DateTimeOffset.Now.AddMinutes(_opt.ExpirationMinutes);
        var token = new JwtSecurityToken(
            issuer: _opt.Issuer,
            audience: _opt.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresAt.UtcDateTime,
            signingCredentials: creds);

        return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
    }
}
