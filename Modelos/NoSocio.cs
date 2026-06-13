
namespace ClubDeportivoApp.Models
{
    public class NoSocio : Cliente
    {
        public int IdNoSocio { get; set; }
        public bool AccesoDiario { get; set; }

        public NoSocio(string nombre, string apellido, string dni, bool aptoFisico)
      : base(nombre, apellido, dni, aptoFisico)
        {

        }

        public NoSocio(int id, string nombre, string apellido, string dni, bool aptoFisico)
            : base(id, nombre, apellido, dni, aptoFisico)
        {
          
        }

        public bool DebePagar()
        {
            return true;
        }

    }
}
