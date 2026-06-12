using ClubDeportivoApp.Repositorios;
using System;


namespace ClubDeportivoApp.Servicios
{
    public class PagoServ
    {
        private PagosRepo repo;

        public PagoServ(PagosRepo repo)
        {
            this.repo = repo;
        }

        public bool RegistrarPagoCuota(int socioId, decimal montoAPagar, decimal montoCuota, int conceptoPago, int medioPago)
        {

            if (montoAPagar < montoCuota)
            {
                return false;
            }

            if (montoAPagar <= 0)
            {
                throw new ArgumentException("El monto debe ser mayor a 0");
            }

           
             int result = repo.RegistrarPagoCuota(socioId, montoAPagar, conceptoPago, medioPago);
                     

            if (result <= 0)
            {
                return false;
            }

            return true;
        }

        public string RegistrarPagoActividad(int noSocioId, int idReserva, decimal montoAPagar, decimal montoActividad, int conceptoPago, int medioPago)
        {
            if (montoAPagar != montoActividad)
            {
                return "Monto a pagar no coincide con el precio de la actividad";
            }

                       
             int result = repo.RegistrarPagoActividad(idReserva, montoAPagar, conceptoPago, medioPago);             
                  


            if (result <= 0)
            {
                return "Error al realizar el pago";
            }

            return "";
        }
    }
}
