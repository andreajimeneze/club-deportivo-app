using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Formularios;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Models;
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

            if (reserva == null)
            {
                return "Reserva no existe, no se puede crear comprobante.";
            }


            string datoPago =reserva.EstadoReserva == "Autorizada" ? "Monto a Pagar: $ 0" : $"Monto a Pagar: $ {Convert.ToString(reserva.Precio)}\n";
           

            string datosReserva =
                //$"Id Reserva: {reserva.IdReserva}" +
                $"Nombre: {reserva.NombreCliente}\n" +
                $"Apellido: {reserva.ApellidoCliente}\n" +
                $"DNI: {reserva.Dni}\n" +
                $"Actividad: {reserva.Actividad}\n" +
                $"Fecha y Hora: {Convert.ToString(reserva.FechaHora)}\n" +
                datoPago;

           

            return datosReserva;            
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
