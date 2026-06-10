using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Repositories;
using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Services
{
    internal class ClienteServ
    {
        private ClienteRepo _repo;

        public ClienteServ(ClienteRepo repo)
        {
            _repo = repo;
        }

        public int RealizarRegistro(string nombre, string apellido, string dni, bool aptoFisico, bool esSocio)
        {
            int clienteId = _repo.RegistrarClienteRepo(nombre, apellido, dni, aptoFisico, esSocio);

            if(clienteId == -1)
            {
                throw new Exception("La persona ya se encuentra registrada");
                
            }

            return clienteId;
        }


        public ClienteDTO BuscarClientePorDni(string dni)
        {
            ClienteDTO clienteBuscado = _repo.BuscarClientePorDniRepo(dni);
            if (clienteBuscado == null)
            {
                return null;
            }

            return clienteBuscado;
        }
    }
}
