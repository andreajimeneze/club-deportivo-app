using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    internal class Cuota
    {
        private int id;
        private string mesVigencia;
        private DateTime fechaVencimiento;
        private string estadoPago;
        private int socioId;
        private List<Pago> pagos;

        public int Id { get => id; set => id = value; }
        public string MesVigencia { get => mesVigencia; set => mesVigencia = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public string EstadoPago { get => estadoPago; set => estadoPago = value; }
        public int SocioId { get => socioId; set => socioId = value; }
        internal List<Pago> Pagos { get => pagos; set => pagos = value; }
    }
}
