using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Inscripcion
    {
        public int Id { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int SocioId { get; set; }

        public Inscripcion() { }

        public Inscripcion(DateTime fechaInscripcion, int socioId)
        {
            this.FechaInscripcion = fechaInscripcion;
            this.SocioId = socioId;
        }
    }
}
