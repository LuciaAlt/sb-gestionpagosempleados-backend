using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SB.Models.Helpers;
using SB.Models.Paginator;
using SB.Services.Interface;

namespace SB.Restful.Controllers
{
    /// <summary>Bitácora del sistema.</summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Constants.Roles.Admin)]
    [Produces("application/json")]
    public class AuditoriaController : ControllerBase
    {
        private readonly IAuditoriaService _service;
        public AuditoriaController(IAuditoriaService service) => _service = service;

        [HttpGet("GetPaginate")]
        public async Task<IActionResult> Get([FromQuery] PaginatorAuditoriaDto request)
        {
            var model = await _service.GetPaginate(request);
            return Ok(model);
        }
    }

}
