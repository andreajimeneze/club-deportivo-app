using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using System.Collections.Generic;


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
        public ListadosMaestrosServ(ConceptoPagoRepo cPagoRepo, MetodoPagoRepo mPagoRepo, ActividadRepo actRepo)
        {
            _cPagorepo = cPagoRepo;
            _mPagoRepo = mPagoRepo;
            _actRepo = actRepo;
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
