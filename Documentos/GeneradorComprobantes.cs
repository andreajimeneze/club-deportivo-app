using ClubDeportivoApp.DTOS;
using System;


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


            string datoPago = reserva.EstadoReserva == "Autorizada" ? "Monto a Pagar: $ 0" : $"Monto a Pagar: $ {Convert.ToString(reserva.Precio)}\n";


            string datosReserva =
                $"Id Reserva: {reserva.IdReserva}\n" +
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
            $"Monto Pagado: $ {Convert.ToString(reserva.Precio)}\n" +
            $"Método Pago: {Convert.ToString(metodoPago)}\n" +
            $"Fecha Pago: {Convert.ToString(DateTime.Now)}\n";
        }

        public static string MostrarComprobantePagoCuota(CuotaDTO cuota, string metodoPago)
        {
            return
            $"Nombre: {cuota.Nombre}\n" +
            $"Apellido: {cuota.Apellido}\n" +
            $"DNI: {cuota.Dni}\n" +
            $"Monto Pagado: $ {Convert.ToString(cuota.MontoCuota)}\n" +
            $"Método Pago: {Convert.ToString(metodoPago)}\n" +
            $"Fecha Pago: {Convert.ToString(DateTime.Now)}\n";
        }
    }
}
