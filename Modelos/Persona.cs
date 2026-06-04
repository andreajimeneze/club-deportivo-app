
namespace ClubDeportivoApp.Models
{
    public class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dni { get; set; }

        public Persona() { }
        public Persona(string nombre, string apellido, string dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }
    }
}
