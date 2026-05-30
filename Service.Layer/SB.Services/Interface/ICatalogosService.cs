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
    public interface ICatalogosService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(CancellationToken ct = default);
        Task<IEnumerable<TipoEmpleadoDto>> GetEmployeeTypesAsync(CancellationToken ct = default);
        Task<IEnumerable<ModuleDto>> GetModulesAsync(CancellationToken ct = default);
    }
}
