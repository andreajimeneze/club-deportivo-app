using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoApp
{
    internal class ConexionMySql : Conexion
    {
        private MySqlConnection conn;
        private string cadenaConexion;

        public ConexionMySql()
        {
            cadenaConexion = "Server=" + server +
                "; Database=" + database + "; Username=" + username
                + "; Password=" + password;

            conn = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection GetMySqlConnection()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                return conn;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
