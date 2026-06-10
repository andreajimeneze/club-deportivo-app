using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositorios;
using System;


namespace ClubDeportivoApp.Servicios
{
    internal class InscripcionSocioServ
    {
        private InscripcionRepo _repo;

        public InscripcionSocioServ(InscripcionRepo repo)
        {
            _repo = repo;
        }

        public bool FormalizarSocio(int socioId, decimal montoCuota)
        {
            try
            {
                if (socioId <= 0 || montoCuota <= 0)
                {
                    return false;
                }

                int result = _repo.FormalizarContrato(socioId, montoCuota);

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
