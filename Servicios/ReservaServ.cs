using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Servicios
{
    public class ReservaServ
    {
        private readonly ReservaRepo _repo;

        public ReservaServ(ReservaRepo repo)
        {
            _repo = repo;
        }

        public ReservaDTO BuscarReservaPorId(int idReserva)
        {
            return _repo.BuscarReservaPorId(idReserva);
        }

        public int GenerarReserva(int idActividad, int clienteId, DateTime fecha_hora)
        {
           return _repo.GenerarReservaRepo(idActividad, clienteId, fecha_hora);
        }
    }
}
