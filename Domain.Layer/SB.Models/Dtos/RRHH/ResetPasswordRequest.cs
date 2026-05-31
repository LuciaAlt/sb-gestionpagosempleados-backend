using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Models.Dtos.RRHH
{
    public class ResetPasswordRequest
    {
        public string Token { get; set; } = string.Empty;
        public string NuevaPassword { get; set; } = string.Empty;
        public string ConfirmarPassword { get; set; } = string.Empty;
    }
}
