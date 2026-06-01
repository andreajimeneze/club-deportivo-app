using ClubDeportivoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Pago : IPago
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public int ConceptoPagoId { get; set; }
        public int MetodoPagoId { get; set; }
        public int? CuotaId { get; set; }
        public int? NoSocioId { get; set; }

        public Pago()
        { }
        public Pago(int? cuotaId, int? noSocioId, DateTime fechaPago, int monto, int conceptoPagoId, int metodoPagoId)
        {
            this.CuotaId = cuotaId;
            this.NoSocioId = noSocioId;
            this.FechaPago = fechaPago;
            this.Monto = monto;
            this.ConceptoPagoId = conceptoPagoId;
            this.MetodoPagoId = metodoPagoId;
        }

        void IPago.RegistrarPago()
        {
            throw new NotImplementedException();
        }

        List<Pago> IPago.listarPagosVencidos()
        {
            throw new NotImplementedException();
        }
    }
 }
