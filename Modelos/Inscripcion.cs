using ClubDeportivoApp.Interfaces;
using System;

namespace ClubDeportivoApp.Models
{
    internal class Inscripcion : IInscripcion
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


        public Inscripcion FormalizarInscripcion()
        {
            throw new NotImplementedException();
        }

        public Cuota EmitirCarnet()
        {
            throw new NotImplementedException();
        }
    }
}
