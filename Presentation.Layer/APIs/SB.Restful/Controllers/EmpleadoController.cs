using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.Models.Dtos.RRHH;
using SB.Models.Helpers;
using SB.Models.Paginator;
using SB.Services.Interface;

namespace SB.Restful.Controllers;

/// <summary>
/// Gestión de empleados. El pago semanal se calcula en backend
/// vía Strategy Pattern según el tipo del empleado.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
[Produces("application/json")]
public class EmpleadoController : ControllerBase
{
    private readonly IEmpleadoService _service;
    public EmpleadoController(IEmpleadoService service) => _service = service;

    /// <summary>Lista empleados paginados con filtros opcionales.</summary>
    [HttpGet("GetPaginate")]
    public async Task<IActionResult> Get([FromQuery] PaginatorEmpleadoDto request)
    {
        var model = await _service.GetPaginate(request);
        return Ok(model);
    }
    /// <summary>Lista de todos los empleados .</summary>
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
    public async Task<IActionResult> Create([FromBody] EmpleadoDtos dto, CancellationToken ct)
    {
        var created = await _service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Actualiza un empleado existente. Solo Admin.</summary>
    [HttpPut("{id:int}")]
    [Authorize(Roles = Constants.Roles.Admin)]
    public async Task<IActionResult> Update(int id, [FromBody] EmpleadoDtos dto, CancellationToken ct)
    {
        var updated = await _service.UpdateAsync(id, dto, ct);
        return Ok(updated);
    }

    /// <summary>Activa o Inactiva un empleado (baja lógica). Solo Admin.</summary>
    [HttpPatch("{id:int}")]
    [Authorize(Roles = Constants.Roles.Admin)]
    public async Task<IActionResult> ActivateOrDeactivate(int id,bool value, CancellationToken ct)
    {
        if (value)
            await _service.ActivateAsync(id, ct);
        else
            await _service.DeactivateAsync(id, ct);

        return NoContent();
    }
    /// <summary>Delete un empleado (baja lógica). Solo Admin.</summary>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = Constants.Roles.Admin)]
    public async Task<IActionResult> Delete(int id, bool value, CancellationToken ct)
    {
        await _service.DeleteAsync(id, ct);
        return NoContent();
    }
}
