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

        public bool ExisteSocioPorId(string dni)
        {
            return _socioRepo.BuscarSocioPorDNI(dni);
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
