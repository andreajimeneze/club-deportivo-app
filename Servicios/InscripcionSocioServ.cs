using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Servicios
{
    internal class InscripcionSocioServ
    {
        private InscripcionSocioRepo repo;

        public InscripcionSocioServ(InscripcionSocioRepo repo)
        {
            this.repo = repo;
        }

        public bool FormalizarInscripcion(int socioId, decimal monto, int conceptoId, int metodoId)
        {
            try
            {
                if (socioId <= 0 || monto <= 0 || conceptoId <= 0 || metodoId <= 0)
                {
                    return false;
                }

                int result = repo.FormalizarSocioRepo(socioId, monto, conceptoId, metodoId);

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
