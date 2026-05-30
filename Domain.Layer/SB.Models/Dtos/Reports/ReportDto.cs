using SB.Entities.Empleados;
namespace SB.Models.Dtos.Reports;
public class ReportDto
{
    public DateTimeOffset FechaGeneracion { get; set; } = DateTimeOffset.Now;
    public int TotalEmpleados { get; set; }
    public decimal TotalPagado { get; set; }
    public IEnumerable<ReportItemDto> Items { get; set; } = Enumerable.Empty<ReportItemDto>();
}
