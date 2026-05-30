using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Models.Dtos.Seguridad
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Icono { get; set; }
        public int Orden { get; set; }
        public IEnumerable<PermisoDto> Permisos { get; set; } = Enumerable.Empty<PermisoDto>();
    }

}
