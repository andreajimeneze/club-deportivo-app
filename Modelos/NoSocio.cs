
namespace ClubDeportivoApp.Models
{
    public class NoSocio : Cliente
    {
        public new int Id { get; set; }
        public bool accesoDiario { get; set; }
        
        //public NoSocio() { }

        public NoSocio(string nombre, string apellido, string dni)
            : base(nombre, apellido, dni)
        {
            accesoDiario = false;
        }
    }
}
