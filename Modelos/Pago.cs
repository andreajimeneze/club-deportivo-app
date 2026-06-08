using ClubDeportivoApp.Modelos;
using System;


namespace ClubDeportivoApp.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public ConceptoPago ConceptoPago { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public Cuota Cuota { get; set; }
        public NoSocio NoSocio { get; set; }

        public Pago()
        { }
        public Pago(Cuota cuota, NoSocio noSocio, DateTime fechaPago, int monto, ConceptoPago conceptoPago, MetodoPago metodoPago)
        {
            this.Cuota = cuota;
            this.NoSocio = noSocio;
            this.FechaPago = fechaPago;
            this.Monto = monto;
            this.ConceptoPago = conceptoPago;
            this.MetodoPago = metodoPago;
        }
    }
 }
