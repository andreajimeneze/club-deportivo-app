using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Interfaces
{
    internal interface IRegistro
    {
        int RegistrarCliente(string nombre, string apellido, string dni, bool aptoFisico);
        int AsignarTipoCliente(int clienteId, bool esSocio);
    }
}
