using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Pago
    {
        private DateTime fechaPago;
        private int monto;
        private string tipoPago;
        private string metodoPago;
        private int numPago;
        private int cuotaId;

        public Pago()
        { }
        public Pago(DateTime fechaPago, int monto, string tipoPago, string metodoPago, int cuotaId)
        {
            this.fechaPago = fechaPago;
            this.monto = monto;
            this.tipoPago = tipoPago;
            this.metodoPago = metodoPago;
            this.cuotaId = cuotaId;
        }

    }
}
