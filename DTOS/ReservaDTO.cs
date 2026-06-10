using System;


namespace ClubDeportivoApp.DTOS
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string Dni { get; set; }
        public int IdActividad { get; set; }
        public string Actividad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaHora { get; set; }
        public string EstadoReserva { get; set; }
    }
}
