using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Models.Dtos.Seguridad
{
    public class RegistrarUsuarioDto
    {
        public int RolId { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string HashContrasena { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
      
        public int RoleId { get; set; } = 2;
    }

}
