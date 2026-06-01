using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoApp.Servicios
{
    internal class ListadosMaestrosServ
    {
        private ListadosMaestrosRepo repo;

        public ListadosMaestrosServ(ListadosMaestrosRepo repo)
        {
            this.repo = repo;
        }

        public List<MetodoPago> ObtenerMetodosPago()
        {
            return repo.ObtenerListadoMetodos();
        }

        public List<ConceptoPago> ObtenerConceptosPago()
        {
            return repo.ObtenerListadoConceptos();
        }

        public List<Actividad> ObtenerActividades()
        {
            return repo.ObtenerListadoActividades();
        }
    }
}
