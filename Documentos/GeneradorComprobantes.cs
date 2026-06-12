using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Formularios;
using ClubDeportivoApp.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Documentos
{
    public static class GeneradorComprobantes
    {
        public static string MostrarComprobanteReserva(ReservaDTO reserva)
        {
            return
            $"Id Reserva: {reserva.IdReserva}" +
            $"Nombre: {reserva.NombreCliente}\n" +
            $"Apellido: {reserva.ApellidoCliente}\n" +
            $"DNI: {reserva.Dni}\n" +
            $"Actividad: {reserva.Actividad}\n" +
            $"Fecha y Hora: {Convert.ToString(reserva.FechaHora)}\n" +
            $"Monto a Pagar: $ {Convert.ToString(reserva.Precio)}\n";
        }

        public static string MostrarComprobantePagoActividad(ReservaDTO reserva, string metodoPago)
        {
            return
            $"Id Reserva: {reserva.IdReserva}\n" +
            $"Nombre: {reserva.NombreCliente}\n" +
            $"Apellido: {reserva.ApellidoCliente}\n" +
            $"DNI: {reserva.Dni}\n" +
            $"Actividad: {reserva.Actividad}\n" +
            $"Fecha y Hora: {Convert.ToString(reserva.FechaHora)}\n" +
            $"Monto a Pagar: $ {Convert.ToString(reserva.Precio)}\n" +
            $"Método Pago: {Convert.ToString(metodoPago)}\n" +
            $"Fecha Pago: {Convert.ToString(DateTime.Now)}\n";
        }
    }
}
