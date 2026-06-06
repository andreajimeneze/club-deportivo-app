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
        public new int Id { get; set; }
        public bool Estado { get; set; }

        public Socio(string nombre, string apellido, string dni)
            : base(nombre, apellido, dni)
        {
            Estado = true;
        }

        public string MostrarCliente()
        {
            return  $"Nombre: {Nombre}" +
                    $"Apellido: {Apellido} " +
                    $"Dni: {Dni}";
        }
    }
}
