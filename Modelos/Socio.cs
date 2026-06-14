using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    public class Socio : Cliente
    {
        public int IdSocio { get; set; }
        public bool Estado { get; set; }

        public Socio(string nombre, string apellido, string dni, bool aptoFisico)
            : base(nombre, apellido, dni, aptoFisico)
        {
        }

        public Socio(int id, string nombre, string apellido, string dni, bool aptoFisico)
            : base(id, nombre, apellido, dni, aptoFisico) 
        {
           
        }

        public Socio(int id, string nombre, string apellido, string dni, bool aptoFisico, bool estado)
            : base(id, nombre, apellido, dni, aptoFisico) 
        {
            Estado = estado;
        }

        public bool EstaActivo()
        {
            return Estado;
        }
    }
}
