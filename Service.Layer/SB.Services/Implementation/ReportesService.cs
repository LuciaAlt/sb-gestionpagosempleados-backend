using Microsoft.Extensions.Logging;
using SB.Models.Contracts;
using SB.Models.Dtos.Reports;
using SB.Services.Interface;
using SB.Services.Strategies;

namespace SB.Services.Implementation
{
    public class ReportesService : IReportesService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IPaymentStrategyResolver _resolver;
        private readonly ILogger<ReportesService> _logger;

        public ReportesService(IEmployeeRepository repo, IPaymentStrategyResolver resolver, ILogger<ReportesService> logger)
        {
            _repo = repo;
            _resolver = resolver;
            _logger = logger;
        }

        public async Task<ReportDto> GenerateWeeklyReportAsync(CancellationToken ct = default)
        {
            _logger.LogInformation("Generando reporte semanal de pagos");
            var employees = (await _repo.GetAllAsync(ct)).Where(e => e.Activo).ToList();

            var items = employees.Select(e =>
            {
                var r = _resolver.Calculate(e);
                return new ReportItemDto
                {
                    EmployeeId = e.Id,
                    NombreCompleto = $"{e.Nombres} {e.Apellidos}".Trim(),
                    NumeroSeguroSocial = e.NumeroSeguroSocial,
                    Departamento = e.Departmento?.Nombre ?? string.Empty,
                    TipoEmpleado = e.TipoCodigo,
                    TipoEmpleadoNombre = e.TipoEmpleado?.Nombre ?? string.Empty,
                    DetalleCalculo = r.Detail,
                    PagoSemanal = r.Amount
                };
            }).ToList();

            var report = new ReportDto
            {
                FechaGeneracion = DateTimeOffset.Now,
                TotalEmpleados = items.Count,
                TotalPagado = items.Sum(i => i.PagoSemanal),
                Items = items
            };

            _logger.LogInformation("Reporte generado: {N} empleados · total {Total:C}", report.TotalEmpleados, report.TotalPagado);
            return report;
        }
    }
}
