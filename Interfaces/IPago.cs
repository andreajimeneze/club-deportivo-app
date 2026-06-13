using ClubDeportivoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Interfaces
{
    public interface IPago
    {
        int RegistrarPago(int ? idSocio, int ? idNoSocio, decimal montoAPagar, int conceptoPago, int medioPago);
        //List<Pago> listarPagosVencidos();
    }

}
