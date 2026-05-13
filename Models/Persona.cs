using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp
{
    internal class Persona
    {
        private string nombre;
        private string apellido;
        private string dni;
        private string direccion;
        private string email;
        private string telefono;

        public Persona()
        { }

        public Persona(string nombre, string apellido, string dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, string direccion, string email, string telefono) : this(nombre, apellido, dni)
        {
            this.direccion = direccion;
            this.email = email;
            this.telefono = telefono;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dni { get => dni; set => dni = value; }

        public override string ToString()
        {
            return $"{apellido}, {nombre}, {dni}";
        }
    }
}
