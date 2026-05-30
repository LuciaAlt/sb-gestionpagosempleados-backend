using AutoMapper;
using Microsoft.Extensions.Logging;
using SB.Models.Base;
using SB.Models.Contracts;
using SB.Models.Dtos.Seguridad;
using SB.Models.Paginator;
using SB.Services.Interface;

namespace SB.Services.Implementation
{
    public class AuditoriaService : IAuditoriaService
    {
        private readonly IAuditLogRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<AuditoriaService> _logger;

        public AuditoriaService(IAuditLogRepository repo, IMapper mapper, ILogger<AuditoriaService> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DataCollection<AuditoriaDto>> GetPaginate(PaginatorAuditoriaDto request, CancellationToken ct = default)
        {
            _logger.LogInformation("Paginando AuditLog. Accion={A} Entidad={E} Usuario={U} Desde={D} Hasta={H}",
                request.Accion, request.Entidad, request.Usuario, request.Desde, request.Hasta);

            var paged = await _repo.GetPagedAsync(
                page: request.Page,
                take: request.Take,
                orderBy: q => q.OrderByDescending(a => a.Fecha),
                predicate: a =>
                    (string.IsNullOrEmpty(request.Accion) || a.Accion == request.Accion)
                    && (string.IsNullOrEmpty(request.Entidad) || a.Entidad == request.Entidad)
                    && (string.IsNullOrEmpty(request.Usuario) || a.UsuarioRegistra == request.Usuario)
                    && (!request.Desde.HasValue || a.Fecha >= request.Desde.Value)
                    && (!request.Hasta.HasValue || a.Fecha <= request.Hasta.Value),
                include: null,
                ct: ct);

            return new DataCollection<AuditoriaDto>
            {
                Items = _mapper.Map<IEnumerable<AuditoriaDto>>(paged.Items),
                Total = paged.Total,
                Page = paged.Page,
                Pages = paged.Pages
            };
        }
    }
}
