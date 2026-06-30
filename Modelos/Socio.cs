
namespace ClubDeportivoApp.Modelos
{
    public class Socio : Cliente
    {
        public int IdSocio { get; set; }
        public bool Estado { get; set; }

        public Socio() { }
        public Socio(string nombre, string apellido, string dni, bool aptoFisico)
            : base(nombre, apellido, dni, aptoFisico)
        {
        }

        public Socio(int idCliente, string nombre, string apellido, string dni, bool aptoFisico)
            : base(idCliente, nombre, apellido, dni, aptoFisico) 
        {
           
        }

        public Socio(int id, string nombre, string apellido, string dni, bool aptoFisico, bool estado)
            : base(id, nombre, apellido, dni, aptoFisico) 
        {
            Estado = estado;
        }

        public bool EstaActivo()
        {
            return Estado;
        }
    }
}
