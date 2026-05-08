using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Socio : Persona
    {
        private bool estado;

        public bool Estado { get => estado; set => estado = value; }
    }
}
