using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Repositorios;


namespace ClubDeportivoApp.Servicios
{
    public class PagoCuotaServ : IPago<CuotaDTO>
    {
        private PagosRepo _repo;
 

        public PagoCuotaServ(PagosRepo repo)
        {
            _repo = repo;
        }

        public (bool Ok, string mensaje, CuotaDTO data) RegistrarPago(CuotaDTO cuota, decimal montoAPagar, int idConceptoPago, int idMedioPago)
        {
                     
            if(cuota == null)
            {
                return (false, "Socio no tiene cuota pendiente", null);
            }
            
            if (montoAPagar < cuota.MontoCuota)
            {
                return (false, "Monto debe ser igual a la cuota", null);
            }

            if (montoAPagar <= 0)
            {
                return(false, "El monto debe ser mayor a 0", null);
            }

           
             int result = _repo.RegistrarPagoCuota(cuota.IdSocio, montoAPagar, idConceptoPago, idMedioPago);
                     

            if (result <= 0)
            {
                return (false, "Error al realizar el registro de cuota", null);
            }
        

            return (true, "Pago registrado con éxito", cuota);
        }

       
          }
}
