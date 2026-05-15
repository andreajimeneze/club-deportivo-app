using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Socio : Persona
    {
        public int id { get; set; }
        public bool Estado { get; set; }
      
        public Socio(string nombre, string apellido, string dni)
            : base(nombre, apellido, dni)
        {
        }
    }
}
