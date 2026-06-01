using ClubDeportivoApp.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Cuota : ICuota
    {
        public int Id { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string EstadoPago { get; set; }
        public int SocioId { get; set; }
        public List<Pago> Pagos { get; set; }

       public Cuota() {
            List<Pago> pagos = new List<Pago>();
                }

      
       public Cuota(DateTime fechaVencimiento, string estadoPago, int socioId)
        {
            this.FechaVencimiento = fechaVencimiento;
            this.EstadoPago = estadoPago;
            this.SocioId = socioId;
        }

        public Cuota ObtenerCuota()
        {
            throw new NotImplementedException();
        }

        public void RegistrarCuota()
        {
            throw new NotImplementedException();
        }

        public List<Cuota> ObtenerCuotasImpagasPorCliente()
        {
            throw new NotImplementedException();
        }

        Cuota ICuota.ObtenerCuotaPorId()
        {
            throw new NotImplementedException();
        }
    }
}
