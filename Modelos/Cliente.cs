using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Models
{
    public class Cliente : Persona
    {
        public new int Id { get; set; }
        public bool AptoFisico { get; set; }

        //public Cliente()
        //{
        //}

        public Cliente(string nombre, string apellido, string dni) 
            :base(nombre, apellido, dni)
        {
            AptoFisico = true;
        }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre}, {Dni}";
        }
    }
}