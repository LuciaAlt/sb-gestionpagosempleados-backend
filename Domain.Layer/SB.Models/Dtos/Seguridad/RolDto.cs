using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Models.Dtos.Seguridad
{
    public class RolDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public IEnumerable<PermisoDto> Permisos { get; set; } = Enumerable.Empty<PermisoDto>();
    }
}
