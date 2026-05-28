using ClubDeportivoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Services
{
    internal class RegistroServ
    {
        private RegistroRepo repo;

        public RegistroServ(RegistroRepo repo)
        {
            this.repo = repo;
        }

        public void realizarRegistro(string nombre, string apellido, string dni, bool aptoFisico, bool esSocio)
        {
            int clienteId = repo.RegistrarCliente(nombre, apellido, dni, aptoFisico);

            if(clienteId == -1)
            {
                throw new Exception("La persona ya se encuentra registrada");
                
            }

            if(aptoFisico != true)
            {
                throw new Exception("Cliente debe presentar certificado para poder acceder a los servicios del club");
               
            }
            repo.AsignarTipoCliente(clienteId, esSocio);
        }
    }
}
