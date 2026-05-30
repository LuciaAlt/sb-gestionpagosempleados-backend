using SB.Models.Dtos.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Services.Interface
{
    public interface IReportesService
    {
        Task<ReportDto> GenerateWeeklyReportAsync(CancellationToken ct = default);
    }
 
}
