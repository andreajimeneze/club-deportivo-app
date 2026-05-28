using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Carnet
    {
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public bool Estado { get; set; }

        public Carnet(int inscripcionId, bool estado)
        {
            this.InscripcionId = inscripcionId;
            this.Estado = estado;
        }
    }
}
