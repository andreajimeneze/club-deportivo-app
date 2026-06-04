using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositorios;
using System;


namespace ClubDeportivoApp.Servicios
{
    internal class InscripcionSocioServ
    {
        private PagosRepo repo;

        public InscripcionSocioServ(PagosRepo repo)
        {
            this.repo = repo;
        }

        public bool FormalizarSocio(int socioId, decimal montoCuota, decimal montoAPagar)
        {
            try
            {
                if (socioId <= 0 || montoCuota <= 0 || montoAPagar < montoCuota)
                {
                    return false;
                }

                int result = repo.FormalizarContrato(socioId, montoCuota);

                if (result > 0)
                {
                    return true;
                }
                return false;
            } catch(Exception ex)
            {
                throw new Exception("Error service inscripción: " + ex.Message, ex);
            }
        }
    }
}
