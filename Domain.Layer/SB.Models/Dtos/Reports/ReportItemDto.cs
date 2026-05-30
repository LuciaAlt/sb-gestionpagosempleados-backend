using SB.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Models.Dtos.Reports
{
    public class ReportItemDto
    {
        public int EmployeeId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string NumeroSeguroSocial { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public CodigoTipoEmpleado TipoEmpleado { get; set; }
        public string TipoEmpleadoNombre { get; set; } = string.Empty;
        public string DetalleCalculo { get; set; } = string.Empty;
        public decimal PagoSemanal { get; set; }
    }

}
