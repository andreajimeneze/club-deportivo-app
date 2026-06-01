using ClubDeportivoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Interfaces
{
    internal interface IPago
    {
        void RegistrarPago();
        List<Pago> listarPagosVencidos();
    }

}
