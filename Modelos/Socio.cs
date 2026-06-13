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
         : base(nombre, apellido, dni, aptoFisico)
        {
            IdSocio = id;
        }

        public Socio(int id, string nombre, string apellido, string dni, bool aptoFisico, bool estado)
            : base(nombre, apellido, dni, aptoFisico)
        {
            IdSocio = id;
            Estado = estado;
        }

        public string MostrarCliente()
        {
            return  $"Nombre: {Nombre}" +
                    $"Apellido: {Apellido} " +
                    $"Dni: {Dni}";
        }

        public bool DebePagar()
        {
            return false;
        }
    }
}
