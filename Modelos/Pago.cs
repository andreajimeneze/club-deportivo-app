using System;


namespace ClubDeportivoApp.Models
{
    internal class Pago
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
    }
 }
