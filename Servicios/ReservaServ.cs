using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using System;
using System.Windows.Forms;

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

            if (reserva == null)
            {
                return null;
            }

            return reserva;
        }

        
        public (bool Ok, string mensaje, ReservaDTO reserva) BuscarReservaPendientePagoPorId(int idReserva)
        {
            ReservaDTO reserva = _repo.BuscarReservaPorId(idReserva);

            if (reserva == null)
            {
                return (false, "Reserva no existe", null);
            }

            if (reserva != null && reserva.EstadoReserva != "Pendiente de pago")
            {
                return (false, "Reserva se encuentra pagada", null);
            }

            if (reserva.FechaHora.Date < DateTime.Today)
                return (false, "Reserva no vigente", null);

            return (true, "Reserva obtenida exitosamente", reserva);
        }

        public (bool Ok, string mensaje, ReservaDTO reserva) BuscarReservaExistentePorDniYActividad(string dni, int idActividad)
        {
            ReservaDTO reserva = _repo.BuscarReservaPorDniYActividadRepo(dni, idActividad);

            if (reserva == null)
            {
                return (false, "Reserva no existe", null);
            }
            return (true, "Reserva obtenida exitosamente", reserva);
        }
        public (bool Ok, string mensaje, ReservaDTO reserva) BuscarReservaPendientePorDniYActividad(string dni, int idActividad)
        {
            ReservaDTO reserva = _repo.BuscarReservaPorDniYActividadRepo(dni, idActividad);

            if(reserva == null)
            {
                return (false, "Reserva no existe", null);
            }

            if(reserva != null && reserva.EstadoReserva != "Pendiente de pago")
            {
                return (false, "Reserva se encuentra pagada", null);
            }

            if (reserva.FechaHora.Date < DateTime.Today)
                return (false, "Reserva no vigente", null);

            return (true, "Reserva obtenida exitosamente", reserva);
        }
        public (bool Ok, string mensaje, ReservaDTO reserva) GenerarReserva(
            Actividad actividad, Cliente cliente, Programacion programacion)
        {
            // Validación 1: Si está activo
            if (cliente is Socio socio && !socio.EstaActivo())
            {
                return (false, "El socio no está activo. Debe regularizar sus cuotas.", null);
            }

            if (!cliente.TieneAptoFisico())
            {
             return (false, "El cliente no tiene apto físico. No puede reservar.", null);
                
            }

           if (programacion == null)
            {
                return (false, "No se encontró programación.", null);
            }

            if (!programacion.EstaVigente())
            {
                return (false, "Actividad no está vigente.", null);
            }

            if(!programacion.EstaDisponible())
            {
                return (false, "Actividad no tiene cupos disponibles.", null);
            }

            var reservaBuscada = BuscarReservaExistentePorDniYActividad(cliente.Dni, actividad.Id);

            if(reservaBuscada.reserva != null)
            {
                return (false, "Reserva ya fue realizada por el cliente", null);
            }

            int idReserva = _repo.GenerarReservaRepo(
                actividad.Id, cliente.IdCliente, programacion.FechaHora);

            if (idReserva <= 0)
                return (false, "Error inesperado al crear la reserva.", null);

            ReservaDTO reserva = BuscarReservaPorId(idReserva);


            if(reserva == null)
            {
                return (false, "Error al intentar obtener la reserva", null);
            }


            if (cliente is Socio)
            {
                programacion.DescontarCupo();
                return (true, "Reserva autorizada. El socio no debe abonar el servicio.", reserva);
            }
            else
            {
                return (true, "Reserva creada. El cliente debe abonar el servicio.", reserva);
            }
        }
    }
}
