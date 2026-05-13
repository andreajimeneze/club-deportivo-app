using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Pago
    {
        private int id;
        private DateTime fechaPago;
        private decimal monto;
        private string tipoPago;
        private string metodoPago;
        private int numPago;
        private int cuotaId;
        private int noSocioId;

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

        public int Id { get => id; set => id = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public string TipoPago { get => tipoPago; set => tipoPago = value; }
        public string MetodoPago { get => metodoPago; set => metodoPago = value; }
        public int NumPago { get => numPago; set => numPago = value; }
        public int CuotaId { get => cuotaId; set => cuotaId = value; }
        public int NoSocioId { get => noSocioId; set => noSocioId = value; }

        }
    }
