using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Interfaces
{
    internal interface IContrato
    {
        int FormalizarContrato(int idSocio, decimal montoCuota);
    }
}
