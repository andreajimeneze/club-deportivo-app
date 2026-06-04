using System;
using System.Collections.Generic;


namespace ClubDeportivoApp.Models
{
    internal class Cuota 
    {
        public int Id { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string EstadoPago { get; set; }
        public int SocioId { get; set; }
        public decimal MontoCuota { get; set; }
        public List<Pago> Pagos { get; set; }

       public Cuota() {
            List<Pago> pagos = new List<Pago>();
                }

      
       public Cuota(decimal montoCuota, DateTime fechaVencimiento, string estadoPago, int socioId)
        {
            this.MontoCuota = montoCuota;
            this.FechaVencimiento = fechaVencimiento;
            this.EstadoPago = estadoPago;
            this.SocioId = socioId;
        }
    }
}
