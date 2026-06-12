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
            ReservaDTO reserva = _repo.BuscarReservaPorId(idReserva);

            if (reserva == null || reserva.EstadoReserva != "Pendiente de pago")
            {
                return null;
            }

            return reserva;
        }

        public ReservaDTO BuscarReservaPorDniYActividad(string dni, int idActividad)
        {
            ReservaDTO reserva = _repo.BuscarReservaPorDniYActividadRepo(dni, idActividad);

            if(reserva == null || reserva.EstadoReserva != "Pendiente de pago")
            {
                return null;
            }

            return reserva;
        }
        public ReservaDTO GenerarReserva(int idActividad, int clienteId, DateTime fecha_hora)
        {
           int idReserva = _repo.GenerarReservaRepo(idActividad, clienteId, fecha_hora);

            if(idReserva <= 0) {
                return null;
            }

            return _repo.BuscarReservaPorId(idReserva);


        }
    }
}
