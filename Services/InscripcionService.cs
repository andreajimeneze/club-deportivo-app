using ClubDeportivoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Services
{
    internal class InscripcionService
    {
        private InscripcionRepository repository;

        public InscripcionService(InscripcionRepository repopository)
        {
            this.repository = repopository;
        }

        public void realizarRegistro(string nombre, string apellido, string dni, bool esSocio)
        {
            int personaId = repository.RegistrarPersona(nombre, apellido, dni, esSocio);

            if(personaId == -1)
            {
                throw new Exception("La persona ya se encuentra registrada");
            }
            if(esSocio)
            {
                repository.AgregarASocio(personaId);
            } else
            {
                repository.AgregarANoSocio(personaId);
            }
        }
    }
}
