using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SB.Models.Contracts;
using SB.Models.Helpers;

namespace SB.Helpers.CurrentUser;

/// <summary>
/// Lee el usuario autenticado del HttpContext en cada request.
/// Si no hay HttpContext (jobs, seeds) devuelve "SYSTEM".
/// Lo usa el AuditableInterceptor de EF Core para llenar los campos auditables.
/// </summary>
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _accessor;

    public CurrentUserService(IHttpContextAccessor accessor) => _accessor = accessor;

    public string Username
    {
        get
        {
            var u = _accessor.HttpContext?.User;
            if (u?.Identity?.IsAuthenticated != true) return Constants.System.SystemUser;
            return u.FindFirstValue(ClaimTypes.Name)
                ?? u.FindFirstValue("unique_name")
                ?? Constants.System.Anonimo;
        }
    }

    public int? UserId
    {
        get
        {
            var s = _accessor.HttpContext?.User?.FindFirstValue("sub")
                 ?? _accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(s, out var id) ? id : null;
        }
    }

    public string? Ip => _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
}
