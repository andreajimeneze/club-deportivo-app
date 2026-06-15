using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
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

        public ReservaDTO BuscarReservaPendientePagoPorId(int idReserva)
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
        public (bool Ok, string mensaje, ReservaDTO reserva) GenerarReserva(
            Actividad actividad, Cliente cliente, Programacion programacion)
        {
            // Validación 1: Si está activo
            if (cliente is Socio socio && !socio.EstaActivo())
            {
                return (false, "El socio no está activo. Debe regularizar sus cuotas.", null);
            }

            if (!cliente.PuedeReservar())
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
           
            int idReserva = _repo.GenerarReservaRepo(
                actividad.Id, cliente.IdCliente, programacion.FechaHora);

            MessageBox.Show($"actividad.Id: {actividad.Id}\n" +
                $"cliente.IdCliente: {cliente.IdCliente}\n" +
                $"programacion.FechaHora: {programacion.FechaHora}\n" +
                $"idReserva devuelto: {idReserva}");

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
