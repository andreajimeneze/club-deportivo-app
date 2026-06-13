using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositorios;
using System;


namespace ClubDeportivoApp.Servicios
{
    public class InscripcionSocioServ
    {
        private InscripcionRepo _repo;

        public InscripcionSocioServ(InscripcionRepo repo)
        {
            _repo = repo;
        }

        public (bool Ok, string mensaje, int idInscripcion) FormalizarSocio(Socio socio, Cuota cuota)
        {
            try
            {
                if (socio.IdSocio <= 0 || cuota.MontoCuota <= 0)
                {
                    return (false, "Cliente o cuota no válidas", 0);
                }

                int idInscripcion = _repo.FormalizarInscripcion(socio.IdSocio, cuota.MontoCuota);

                if (idInscripcion <= 0)
                {
                    return (false, "Error al realizar la inscripción del socio", 0);
                }

                //Inscripcion inscripcion = new Inscripcion(idInscripcion, socio);

                return (true, "Cliente inscrito como socio de manera exitosa", idInscripcion);

            } catch(Exception ex)
            {
                throw new Exception("Error service inscripción: " + ex.Message, ex);
            }
        }
    }
}
