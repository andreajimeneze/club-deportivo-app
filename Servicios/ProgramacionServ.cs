using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Servicios
{
    internal class ProgramacionServ
    {
        private readonly ProgramacionRepo _progRepo;

        public ProgramacionServ(ProgramacionRepo progRepo)
        {
            _progRepo = progRepo;
        }

        public List<Programacion> ObtenerProgramacionPorActividad(int idActividad)
        {
            return _progRepo.BuscarProgramacionPorActividad(idActividad);
        }
    }
}
