using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Modelos
{
    public class Programacion
    {
        public int Id { get; set; }
        public Actividad Actividad { get; set; }
        public DateTime FechaHora { get; set; }
        public int CuposDisponibles { get; set; }
    }
}
