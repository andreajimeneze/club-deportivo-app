using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClubDeportivoApp
{
    public class ConexionMySql : Conexion
    {
        private MySqlConnection conn;
        private string cadenaConexion;

        public ConexionMySql()
        {



        }

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