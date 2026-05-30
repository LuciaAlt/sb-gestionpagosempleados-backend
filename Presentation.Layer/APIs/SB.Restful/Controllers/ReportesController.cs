using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.Services.Interface;

namespace SB.Restful.Controllers
{
    /// <summary>Reportes de nómina.</summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class ReportesController : ControllerBase
    {
        private readonly IReportesService _service;
        public ReportesController(IReportesService service) => _service = service;

        /// <summary>Reporte semanal con cálculo y detalle por empleado.</summary>
        [HttpGet("weekly")]
        public async Task<IActionResult> Weekly(CancellationToken ct)
            => Ok(await _service.GenerateWeeklyReportAsync(ct));
    }
}
