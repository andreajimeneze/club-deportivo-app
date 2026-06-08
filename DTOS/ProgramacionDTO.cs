using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.DTOS
{
    public class ProgramacionDTO
    {
        public int IdProgramacion { get; set; }
        public DateTime FechaHora { get; set; }
        public int CuposDisponibles { get; set; }
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; }
        public decimal PrecioActividad { get; set; }
    }
}
