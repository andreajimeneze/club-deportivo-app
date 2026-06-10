using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Modelos
{
    public class Programacion
    {
        public int Id { get; set; }
        public Actividad Actividad { get; set; }
        public DateTime FechaHora { get; set; }
        public int CuposDisponibles { get; set; }

        public string Descripcion
        {
            get
            {
                if (Id == 0)
                    return "Seleccione fecha y horario";

                return FechaHora.ToString("dd/MM/yyyy HH:mm");
            }
        }

        public string FormatoFechaHora()
        {
            return FechaHora.ToString("dd/MM/yyyy HH:mm");
        }

        public bool EstaDisponible()
        {
            if(CuposDisponibles <= 0)
            {
                return false;
            }
            return true;
        }

        public void DescontarCupo()
        {
            if(CuposDisponibles <= 0)
            {
                throw new Exception("No hay cupos disponibles");
            }
            CuposDisponibles--;
        }
    }
}
