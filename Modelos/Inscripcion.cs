
using System;

namespace ClubDeportivoApp.Models
{
    public class Inscripcion 
    {
        public int Id { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public Socio Socio { get; set; }

        public Inscripcion() { }

        public Inscripcion(int id, Socio socio)
        {
            this.Id = id;
            this.FechaInscripcion = DateTime.Now;
            this.Socio = socio;
        }
    }
}
