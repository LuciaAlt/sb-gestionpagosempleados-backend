using SB.Models.Base;
using SB.Models.Dtos.Seguridad;
using SB.Models.Paginator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Services.Interface
{
    public interface IUsuariosService
    {
        Task<DataCollection<UsuarioDto>> GetPaginate(PaginatorUserDto request, CancellationToken ct = default);
        Task<UsuarioDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<UsuarioDto> CreateAsync(UsuarioDto dto, CancellationToken ct = default);
        Task<UsuarioDto> UpdateAsync(int id, UsuarioDto dto, CancellationToken ct = default);
        Task DeactivateAsync(int id, CancellationToken ct = default);
        Task ActivateAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<UsuarioDto>> GetAllAsync(CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
        Task UnlockAsync(int id, CancellationToken ct = default);
        Task BlockAsync(int id, CancellationToken ct = default);
    }
}
