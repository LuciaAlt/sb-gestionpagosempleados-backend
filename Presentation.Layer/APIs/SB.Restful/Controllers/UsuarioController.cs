using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.Models.Dtos.Seguridad;
using SB.Models.Helpers;
using SB.Models.Paginator;
using SB.Services.Interface;

namespace SB.Restful.Controllers
{
    /// <summary>Gestión de usuarios.</summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Constants.Roles.Admin)]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosService _service;
        public UsuarioController(IUsuariosService service) => _service = service;

        /// <summary>Lista usuarios paginados con filtros.</summary>
        [HttpGet("GetPaginate")]
        public async Task<IActionResult> Get([FromQuery] PaginatorUserDto request)
        {
            var model = await _service.GetPaginate(request);
            return Ok(model);
        }

        /// <summary>Lista de todos los usuarios .</summary>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var model = await _service.GetAllAsync();
            return Ok(model);
        }
        /// <summary>Obtiene un empleado por Id.</summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var dto = await _service.GetByIdAsync(id, ct);
            return dto is null ? NotFound() : Ok(dto);
        }

        /// <summary>Registra un nuevo empleado. Solo Admin.</summary>
        [HttpPost]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<IActionResult> Create([FromBody] UsuarioDto dto, CancellationToken ct)
        {
            var created = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>Actualiza un empleado existente. Solo Admin.</summary>
        [HttpPut("{id:int}")]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto dto, CancellationToken ct)
        {
            var updated = await _service.UpdateAsync(id, dto, ct);
            return Ok(updated);
        }

        /// <summary>Activa o Inactiva un usuario (baja lógica). Solo Admin.</summary>
        [HttpPatch("{id:int}")]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<IActionResult> ActivateOrDeactivate(int id, [FromQuery] bool value, CancellationToken ct)
        {
            if (value)
                await _service.ActivateAsync(id, ct);
            else
                await _service.DeactivateAsync(id, ct);

            return NoContent();
        }
        /// <summary>Desbloquear Or bloquear un usuario (baja lógica). Solo Admin.</summary>
        [HttpPatch("{id:int}/block")]
        public async Task<IActionResult> UnlockOrBlock(int id, [FromQuery] bool value, CancellationToken ct)
        {
            if (value)
                await _service.BlockAsync(id, ct);
            else
                await _service.UnlockAsync(id, ct);

            return NoContent();
        }
        /// <summary>Delete un usuario (baja lógica). Solo Admin.</summary>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<IActionResult> Delete(int id, bool value, CancellationToken ct)
        {
            await _service.DeleteAsync(id, ct);
            return NoContent();
        }
    }
}
