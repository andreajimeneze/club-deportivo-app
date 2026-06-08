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
        private ConceptoPagoRepo _cPagorepo;
        private MetodoPagoRepo _mPagoRepo;
        private ActividadRepo _actRepo;
             
        public ListadosMaestrosServ(ActividadRepo actRepo)
        {
            _actRepo = actRepo;         
        }
        public ListadosMaestrosServ(ConceptoPagoRepo cPagoRepo, MetodoPagoRepo mPagoRepo)
        {
            _cPagorepo = cPagoRepo;
            _mPagoRepo = mPagoRepo;
        }

        public List<MetodoPago> ObtenerMetodosPago()
        {
            return _mPagoRepo.ObtenerLista();
        }

        public List<ConceptoPago> ObtenerConceptosPago()
        {
            return _cPagorepo.ObtenerLista();
        }

        public List<Actividad> ObtenerActividades()
        {
            return _actRepo.ObtenerLista();
        }
    }
}
