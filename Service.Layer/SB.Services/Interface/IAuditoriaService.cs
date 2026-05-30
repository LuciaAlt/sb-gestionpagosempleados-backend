using SB.Models.Base;
using SB.Models.Dtos.RRHH;
using SB.Models.Dtos.Seguridad;
using SB.Models.Paginator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Services.Interface
{
  public interface IAuditoriaService
    {
        Task<DataCollection<AuditoriaDto>> GetPaginate(PaginatorAuditoriaDto request, CancellationToken ct = default);
    }
}
