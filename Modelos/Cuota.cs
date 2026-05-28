using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Cuota
    {
        public int Id { get; set; }
        public string MesVigencia { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string EstadoPago { get; set; }
        public int SocioId { get; set; }
        public List<Pago> Pagos { get; set; }

       public Cuota() {
            List<Pago> pagos = new List<Pago>();
                }

      
       public Cuota(string mesVigencia, DateTime fechaVencimiento, string estadoPago, int socioId)
        {
            this.MesVigencia = mesVigencia;
            this.FechaVencimiento = fechaVencimiento;
            this.EstadoPago = estadoPago;
            this.SocioId = socioId;
        }
    }
}
