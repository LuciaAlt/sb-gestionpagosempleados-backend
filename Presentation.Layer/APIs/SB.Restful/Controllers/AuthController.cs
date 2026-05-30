using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.Models.Dtos.Auth;
using SB.Models.Dtos.RRHH;
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

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword(
    [FromBody] ForgotPasswordRequest request,
    CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.UsuarioOCorreo))
            return BadRequest(new { message = "Debe ingresar el usuario o correo electrónico." });

        //await _authService.ForgotPasswordAsync(request.UsuarioOCorreo, ct);

        return Ok(new
        {
            message = "Si el usuario existe, se enviarán las instrucciones para restablecer la contraseña."
        });
    }
    [HttpGet("validate-reset-token")]
    [AllowAnonymous]
    public async Task<IActionResult> ValidateResetToken(
    [FromQuery] string token,
    CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(token))
            return BadRequest(new { message = "El token es requerido." });

        //var isValid = await _authService.ValidateResetTokenAsync(token, ct);

        //if (!isValid)
        //    return BadRequest(new { message = "El token no es válido o ha expirado." });

        return Ok(new { valid = true });
    }
    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(
    [FromBody] ResetPasswordRequest request,
    CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Token))
            return BadRequest(new { message = "El token es requerido." });

        if (string.IsNullOrWhiteSpace(request.NuevaPassword))
            return BadRequest(new { message = "La nueva contraseña es requerida." });

        if (request.NuevaPassword != request.ConfirmarPassword)
            return BadRequest(new { message = "Las contraseñas no coinciden." });

        //await _authService.ResetPasswordAsync(request, ct);

        return Ok(new { message = "Contraseña restablecida correctamente." });
    }
}
