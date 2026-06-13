using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositorios;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public (bool Ok, string mensaje, ReservaDTO) GenerarReserva(
            Actividad actividad, Cliente cliente, Programacion programacion)
        {
            if (!PuedeReservar(cliente))
            {
                // Validación 1: Si es apto o si no está activo
                if (!cliente.AptoFisico)
                    return (false, "El cliente no tiene apto físico. No puede reservar.", null);

                return (false, "El socio no está activo. Debe regularizar sus cuotas.", null);
            }

            int idReserva = _repo.GenerarReservaRepo(
                actividad.Id, cliente.IdCliente, programacion.FechaHora);

            MessageBox.Show($"actividad.Id: {actividad.Id}\n" +
                $"cliente.IdCliente: {cliente.IdCliente}\n" +
                $"programacion.FechaHora: {programacion.FechaHora}\n" +
                $"idReserva devuelto: {idReserva}");

            // Validación 2: Respecto del Stored Procedure
            if (idReserva == -1)
                return (false, "No se encontró programación para la fecha indicada.", null);
            if (idReserva == -2)
                return (false, "No hay cupos disponibles para esta actividad.", null);
            if (idReserva == -3)
                return (false, "El cliente ya tiene una reserva para esta programación.", null);
            if (idReserva <= 0)
                return (false, "Error inesperado al crear la reserva.", null);

            // *** FIX: usar método correcto según tipo de cliente ***
            ReservaDTO reserva;

            if (cliente is Socio)
            {
                // La reserva del socio queda 'Autorizada', no 'Pendiente de pago'
                // BuscarReservaPorId filtra solo 'Pendiente de pago' → no la encontraría
                reserva = _repo.BuscarReservaAutorizadaPorId(idReserva); // ver repo abajo
                return (true, "Reserva autorizada. El socio no debe abonar el servicio.", reserva);
            }
            else
            {
                // No socio → estado 'Pendiente de pago' → el método existente funciona
                reserva = _repo.BuscarReservaPorId(idReserva);
                return (true, "Reserva creada. El cliente debe abonar el servicio.", reserva);
            }
        }
        public bool PuedeReservar(Cliente cliente)
        {
            if(!cliente.AptoFisico)
            {
                return false;
            }

            if(cliente is Socio socio)
            {
                return socio.Estado;
            }
            
            return true;
        }
    }
}
