using System;

namespace ClubDeportivoApp.DTOS
{
    public class CuotaPendienteDTO
    {
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; } 
        public bool EstadoSocio { get; set; }
        public decimal MontoCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string EstadoCuota { get; set; }

    }
}
