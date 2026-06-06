
using System;

namespace ClubDeportivoApp.Models
{
    public class Inscripcion 
    {
        public int Id { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int SocioId { get; set; }

        public Inscripcion() { }

        public Inscripcion(int socioId)
        {
            this.FechaInscripcion = DateTime.Now;
            this.SocioId = socioId;
        }
    }
}
