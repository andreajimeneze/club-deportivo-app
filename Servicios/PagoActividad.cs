using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositorios;
using System;


namespace ClubDeportivoApp.Servicios
{
    public class PagoActividad : IPago<ReservaDTO>
    {
        private PagosRepo _repo;

        public PagoActividad(PagosRepo repo)
        {
            _repo = repo;
        }

        public (bool Ok, string mensaje, ReservaDTO data) RegistrarPago(ReservaDTO reserva, decimal montoAPagar, int idConceptoPago, int idMedioPago)
        {
          
            if(reserva == null)
            {
                
            }

            if(reserva.EstadoReserva != "Pendiente de pago")
            {
                return (false, "No existe reserva pendiente de pago", null);
            }

            if (montoAPagar <= 0)
            {
                return (false, "El monto debe ser mayor a 0", null);
            }

            if (montoAPagar < reserva.Precio)
            {
                return (false, "Monto a pagar no coincide con el monto de la actividad", null);
            }
                     

           
             int result = _repo.RegistrarPagoActividad(reserva.IdReserva, montoAPagar, idConceptoPago, idMedioPago);
                     

            if (result <= 0)
            {
                return (false, "No se pudo procesar el pago", null);
            }

            reserva.EstadoReserva = "Pagada";

            return (true, "Pago realizado con éxito", reserva);
        }

        //public string RegistrarPagoActividad(int noSocioId, int idReserva, decimal montoAPagar, decimal montoActividad, int conceptoPago, int medioPago)
        //{
        //    if (montoAPagar != montoActividad)
        //    {
        //        return "Monto a pagar no coincide con el precio de la actividad";
        //    }

                       
        //     int result = repo.RegistrarPagoActividad(idReserva, montoAPagar, conceptoPago, medioPago);             
                  


        //    if (result <= 0)
        //    {
        //        return "Error al realizar el pago";
        //    }

        //    return "";
        //}

        //public string RegistrarPagoActividad(ReservaDTO reserva, decimal montoAPagar,  int idConceptoPago, int idMedioPago)
        //{
        //    if (montoAPagar != reserva.Precio)
        //    {
        //        return "Monto a pagar no coincide con el precio de la actividad";
        //    }


        //    int result = repo.RegistrarPagoActividad(reserva.IdReserva, montoAPagar, idConceptoPago, idMedioPago);



        //    if (result <= 0)
        //    {
        //        return "Error al realizar el pago";
        //    }

        //    return "";
        //}
    }
}
