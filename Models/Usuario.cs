using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    public class Usuario : Persona
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public bool Activo { get; set; }

        public Usuario() { }
        
        public Usuario(string nombre, string apellido, string dni)
           : base(nombre, apellido, dni)
        {
        }

        public Usuario(string username, int rolId)
        {
            this.Username = username;
            this.RolId = rolId;
        }
    }
}
