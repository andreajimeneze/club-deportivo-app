using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositories;
using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoApp.Services
{
    public class ClienteServ
    {
        private ClienteRepo _repo;

        public ClienteServ(ClienteRepo repo)
        {
            _repo = repo;
        }

        public (bool Ok, string mensaje, Cliente cliente) RealizarRegistro(Cliente cliente, bool esSocio)
        {
            if (cliente == null)
            {
                return (false, "No se puede realizar registro sin información", null);
            }
            
            Cliente clienteBuscado = BuscarClientePorDni(cliente.Dni);

            if(clienteBuscado != null) {
                return (false, "Cliente ya se encuentra registrado", null);
            }
           
            int idRegistrado = _repo.RegistrarClienteRepo(cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.AptoFisico, esSocio);

            
            if(idRegistrado <= 0)
            {
                return (false, "Error al realizar el registro", null);
                
            }
            cliente.IdCliente = idRegistrado;

            // Si es socio, asignar también IdSocio
            if (esSocio && cliente is Socio socio)
            {
                socio.IdSocio = idRegistrado;  
            }

            return (true, "Cliente registrado con éxito", cliente);


        }


        public Cliente BuscarClientePorDni(string dni)
        {
            Cliente clienteBuscado = _repo.BuscarClientePorDniRepo(dni);
            if (clienteBuscado == null)
            {
                return null;
            }

            return clienteBuscado;
        }

        //private Cliente MapearADominio(ClienteDTO dto)
        //{
        //    if (dto == null) return null;

        //    if (dto.EsSocio)
        //    {
        //        // Usar el constructor que acepta (int id, string nombre, string apellido, string dni, bool aptoFisico, bool estado)
        //        return new Socio(
        //            dto.IdCliente, 
        //            dto.Nombre, 
        //            dto.Apellido, 
        //            dto.Dni, 
        //            dto.AptoFisico, 
        //            dto.Estado);
        //    }

        //    return new NoSocio(
            
        //        dto.IdCliente,
        //        dto.Nombre,
        //        dto.Apellido,
        //        dto.Dni,
        //        dto.AptoFisico            
        //    );
        //}
    }
}
