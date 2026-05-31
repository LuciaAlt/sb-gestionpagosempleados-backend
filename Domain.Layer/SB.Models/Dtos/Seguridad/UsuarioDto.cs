using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Models.Dtos.Seguridad
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string? HashContrasena { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string? RolNombre { get; set; }
        public bool Activo { get; set; }
        public bool Bloqueado { get; set; }
        public DateTimeOffset? FechaCambioContrasena { get; set; }
        public DateTimeOffset? UltimoAcceso { get; set; }

        public string? NombreCompleto => $"{Nombres} {Apellidos}";
    }
}
