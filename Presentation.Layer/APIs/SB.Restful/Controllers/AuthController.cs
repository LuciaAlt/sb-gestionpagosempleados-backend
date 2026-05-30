using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.Models.Dtos.Auth;
using SB.Models.Helpers;
using SB.Services.Interface;

namespace SB.Restful.Controllers;

/// <summary>Autenticación y emisión de JWT.</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;
    public AuthController(IAuthService service) => _service = service;

    /// <summary>
    /// Autentica un usuario y devuelve un JWT.
    /// Usuarios precargados: `admin/Admin123!` (ADMIN), `usuario/User123!` (USUARIO).
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request, CancellationToken ct)
    {
        var model = await _service.LoginAsync(request, ct);
        return Ok(model);
    }
   
}
