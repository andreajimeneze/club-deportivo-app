using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Pago
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string TipoPago { get; set; }
        public string MetodoPago { get; set; }
        //public int NumPago { get; set; }
        public int CuotaId { get; set; }
        public int NoSocioId { get; set; }

        public Pago()
        { }
        public Pago(DateTime fechaPago, int monto, string tipoPago, string metodoPago, int cuotaId)
        {
            this.FechaPago = fechaPago;
            this.Monto = monto;
            this.TipoPago = tipoPago;
            this.MetodoPago = metodoPago;
            this.CuotaId = cuotaId;
        }
    }
 }
