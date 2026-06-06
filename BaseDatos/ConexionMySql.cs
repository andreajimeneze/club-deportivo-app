using MySql.Data.MySqlClient;
using System;


namespace ClubDeportivoApp
{
    public class ConexionMySql : Conexion
    {
        private MySqlConnection conn;
        private string cadenaConexion;

        public MySqlConnection GetMySqlConnection()
        {
            cadenaConexion = $"Server={Server}; Database={Database}; Username={Username}; Password={Password}";
            try
            {
                conn = new MySqlConnection(cadenaConexion);
                conn.Open();

                return conn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}