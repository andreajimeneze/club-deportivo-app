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

        

        public (bool Ok, string mensaje, CuotaDTO cuota) ObtenerCuotaPendienteServ(string dni)
        {
            CuotaDTO cuota = _socioRepo.ObtenerCuotasRepo(dni)
                .Where(c => c.EstadoCuota == "Pendiente")
                .OrderBy(c => c.FechaVencimiento)
                .FirstOrDefault();

            if(cuota == null)
            {
                return (false, "Cuota no existe", null);
            }

            return (true, "Cuota pendiente obtenida con éxito", cuota);
        }
    }
}
