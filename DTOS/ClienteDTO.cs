
namespace ClubDeportivoApp.DTOS
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public bool AptoFisico { get; set; }
        public bool EsSocio { get; set; }
        public bool Estado { get; set; }
    }
}
