using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Models.Dtos.Seguridad
{
    public class AuditoriaDto
    {
        public int Id { get; set; }
        public string? UsuarioRegistra { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string Entidad { get; set; } = string.Empty;
        public int? EntidadId { get; set; }
        public string? Detalle { get; set; }
        public string? Ip { get; set; }
        public DateTimeOffset Fecha { get; set; }
    }
}
