
using System;

namespace ClubDeportivoApp.Modelos
{
    public class Cliente : Persona
    {
        public int IdCliente { get; set; }
        public bool AptoFisico { get; set; }

        public Cliente() { }

        public Cliente(string nombre, string apellido, string dni, bool aptoFisico)
        : base(nombre, apellido, dni)
        {
            AptoFisico = aptoFisico;
        }
        public Cliente(int id, string nombre, string apellido, string dni, bool aptoFisico) 
            :base(nombre, apellido, dni)
        {
            IdCliente = id;
            AptoFisico = aptoFisico;
        }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre}, {Dni}";
        }
        
        public bool TieneAptoFisico()
        {
            return AptoFisico;
        }
        public bool PuedeReservar()
        {
            return AptoFisico;
        }
    }
}