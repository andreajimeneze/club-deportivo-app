using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.DTOS
{
    public class CuotaPendienteDTO
    {
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; } 
        public bool EstadoSocio { get; set; }
        public decimal MontoCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }

    }
}
