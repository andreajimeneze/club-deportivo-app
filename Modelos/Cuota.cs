using System;
using System.Collections.Generic;


namespace ClubDeportivoApp.Models
{
    public class Cuota 
    {
        public int Id { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string EstadoPago { get; set; }
        public Socio Socio { get; set; }
        public decimal MontoCuota { get; set; }
        public List<Pago> Pagos { get; set; }

       public Cuota() {
            List<Pago> pagos = new List<Pago>();
                }

        public Cuota(decimal montoCuota)
        {
            this.MontoCuota = montoCuota;
        }
      
       public Cuota(decimal montoCuota, DateTime fechaVencimiento, string estadoPago, Socio socio)
        {
            this.MontoCuota = montoCuota;
            this.FechaVencimiento = fechaVencimiento;
            this.EstadoPago = estadoPago;
            this.Socio = socio;
        }
    }
}
