using ClubDeportivoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Modelos
{
    public class Reserva
    {
        public int Id { get; set; }
        public Programacion Programacion { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaHoraReserva { get; set; }
        public string Estado { get; set; }

    }
}

