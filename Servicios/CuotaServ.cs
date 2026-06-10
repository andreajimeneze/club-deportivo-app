using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Servicios
{
    public class CuotaServ
    {
        private readonly CuotaRepo _socioRepo;

        public CuotaServ(CuotaRepo socioRepo)
        {
            _socioRepo = socioRepo;
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
