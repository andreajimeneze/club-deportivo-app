using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Servicios
{
    public class SocioServ
    {
        private readonly SocioRepo _socioRepo;

        public SocioServ(SocioRepo socioRepo)
        {
            _socioRepo = socioRepo;
        }

        public ClienteDTO BuscarClientePorDni(string dni)
        {
            ClienteDTO clienteBuscado = _socioRepo.BuscarClientePorDniRepo(dni);
            if(clienteBuscado == null)
            {
                return null;
            }

            return clienteBuscado;
        }

        public CuotaPendienteDTO ObtenerCuotaPendienteServ(string dni)
        {
            CuotaPendienteDTO cuota = new CuotaPendienteDTO();

            if(dni == "" || dni.Length > 10)
            {
                return null;
            }

            cuota = _socioRepo.ObtenerCuotaPendienteRepo(dni);

            if(cuota == null)
            {
                return null;
            }
            return cuota;
        }
    }
}
