using ClubDeportivoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Modelos
{
    internal class Reserva
    {
        public int Id { get; set; }
        public Programacion programacion { get; set; }
        public NoSocio NoSocio { get; set; }
        public DateTime FechaHoraReserva { get; set; }
        public bool Pagada {get; set;}
      
    }
}
