
namespace ClubDeportivoApp.Models
{
    public class Carnet
    {
        public int Id { get; set; }
        public int InscripcionId { get; set; }
        public bool Estado { get; set; }

        public Carnet(int inscripcionId, bool estado)
        {
            this.InscripcionId = inscripcionId;
            this.Estado = estado;
        }
    }
}
