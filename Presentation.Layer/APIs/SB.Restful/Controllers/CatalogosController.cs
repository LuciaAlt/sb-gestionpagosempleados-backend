using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.Services.Interface;

namespace SB.Restful.Controllers
{
    /// <summary>Catálogos de soporte.</summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogosService _service;
        public CatalogosController(ICatalogosService service) => _service = service;

        [HttpGet("departments")]
        public async Task<IActionResult> GetDepartments(CancellationToken ct)
            => Ok(await _service.GetDepartmentsAsync(ct));

        [HttpGet("employee-types")]
        public async Task<IActionResult> GetTypes(CancellationToken ct)
            => Ok(await _service.GetEmployeeTypesAsync(ct));

        [HttpGet("modules")]
        public async Task<IActionResult> GetModules(CancellationToken ct)
            => Ok(await _service.GetModulesAsync(ct));

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles(CancellationToken ct)
           => Ok(await _service.GetModulesAsync(ct));
    }
}
