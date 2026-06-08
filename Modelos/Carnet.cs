
namespace ClubDeportivoApp.Models
{
    public class Carnet
    {
        public int Id { get; set; }
        public Inscripcion Inscripcion { get; set; }
        public bool Estado { get; set; }

        public Carnet(Inscripcion inscripcion, bool estado)
        {
            this.Inscripcion = inscripcion;
            this.Estado = estado;
        }
    }
}
