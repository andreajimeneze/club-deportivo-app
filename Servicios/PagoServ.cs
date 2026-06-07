using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoApp.Servicios
{
    public class PagoServ
    {
        private PagosRepo repo;

        public PagoServ(PagosRepo repo)
        {
            this.repo = repo;
        }

        public bool RegistrarPago(int? socioId, int? noSocioId, decimal montoAPagar, decimal montoCuota, int conceptoPago, int medioPago)
        {
           
            if (socioId.HasValue && montoAPagar < montoCuota)
            {
                MessageBox.Show($"El monto a pagar (${montoAPagar}) es menor que la cuota (${montoCuota})");
                return false;
            }

            if (montoAPagar <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a 0");
                return false;
            }

            int result = repo.RegistrarPago(socioId, noSocioId, montoAPagar, conceptoPago, medioPago);

            if (result <= 0)
            {
                return false;
            }

            return true;
        }

    }
}
