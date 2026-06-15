
using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace ClubDeportivoApp.Helpers
{
    public static class ValidacionDatos
    {
        public static bool SoloLetras(string texto)
        {
            return texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public static bool ValidarDni(string dni, out string mensaje)
        {
            if(string.IsNullOrEmpty(dni))
            {
                mensaje = "Debe ingresar un DNI";
                return false;
            }
            if(!dni.All(char.IsDigit))
            {
                mensaje = "DNI debe contener solo números";
                return false;
            }
            if(dni.Length > 8)
            {
                mensaje = "DNI solo puede contener 8 dígitos";
                return false;
            }

            mensaje = "";
            return true;
        }


        public static bool ValidarMonto(string monto, out string mensaje)
        {
            if(string.IsNullOrEmpty(monto))
            {
                mensaje = "Debe ingresar un monto";
                return false;
            }

            if(!Decimal.TryParse(monto, out _))
            {
                mensaje = "Debe ingresar un monto válido";
                return false;
            }

            mensaje = "";
            return true;
        }
    }
}
