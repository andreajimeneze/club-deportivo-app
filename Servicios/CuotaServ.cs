using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Repositorios;
using System.Collections.Generic;
using System.Linq;


namespace ClubDeportivoApp.Servicios
{
    public class CuotaServ
    {
        private readonly CuotaRepo _socioRepo;

        public CuotaServ(CuotaRepo socioRepo)
        {
            _socioRepo = socioRepo;
        }

        

        public CuotaDTO ObtenerCuotaPendienteServ(string dni)
        {
            //CuotaDTO cuotaPendiente = new CuotaDTO();

            return _socioRepo.ObtenerCuotasRepo(dni)
                .Where(c => c.EstadoCuota == "Pendiente")
                .OrderBy(c => c.FechaVencimiento)
                .FirstOrDefault();

            //cuotaPendiente = cuotas.Find(c => c.EstadoCuota == "Pendiente").

            //if(cuota == null)
            //{
            //    return null;
            //}
            //return cuota;
        }
    }
}
