using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Servicios
{
    internal class RegistroPagoServ
    {
        internal PagosRepo repo;

        public RegistroPagoServ(PagosRepo repo)
        {
            this.repo = repo;
        }

        public bool RegistrarPago(int ? socioId, int ? noSocioId, decimal montoAPagar, decimal montoCuota, int conceptoPago, int medioPago)
        {
            if(montoAPagar < montoCuota || montoAPagar <=0)
            {
                return false;
            }

            repo.RegistrarPago(socioId, noSocioId, montoAPagar, conceptoPago, medioPago);
            return true;
        }
    }
}
