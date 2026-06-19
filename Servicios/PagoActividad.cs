using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Repositorios;


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
    }
}
