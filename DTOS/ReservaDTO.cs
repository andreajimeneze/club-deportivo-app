using ClubDeportivoApp.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.DTOS
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string Dni { get; set; }
        public string Actividad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Pagada { get; set; }
    }
}
