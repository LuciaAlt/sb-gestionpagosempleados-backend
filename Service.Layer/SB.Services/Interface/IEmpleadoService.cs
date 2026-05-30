using SB.Models.Base;
using SB.Models.Dtos.RRHH;
using SB.Models.Paginator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Services.Interface
{
    public interface IEmpleadoService
    {
        Task<EmpleadoDtos?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<DataCollection<EmpleadoDtos>> GetPaginate(PaginatorEmpleadoDto request, CancellationToken ct = default);
        Task<EmpleadoDtos> CreateAsync(EmpleadoDtos dto, CancellationToken ct = default);
        Task<EmpleadoDtos> UpdateAsync(int id, EmpleadoDtos dto, CancellationToken ct = default);
        Task DeactivateAsync(int id, CancellationToken ct = default);
        Task ActivateAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<EmpleadoDtos>> GetAllAsync(CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
