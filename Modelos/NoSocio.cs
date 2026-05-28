using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class NoSocio : Cliente
    {
        public new int Id { get; set; }
        public bool accesoDiario { get; set; }
        
        //public NoSocio() { }

        public NoSocio(string nombre, string apellido, string dni)
            : base(nombre, apellido, dni)
        {
            accesoDiario = false;
        }
    }
}
