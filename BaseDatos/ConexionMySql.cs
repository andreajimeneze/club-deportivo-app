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
    public class ConexionMySql : Conexion
    {
        private MySqlConnection conn;
        private string cadenaConexion;

        public ConexionMySql()
        {
            cadenaConexion = "Server=" + server +
                "; Database=" + database + "; Username=" + username
                + "; Password=" + password;


        }

        public MySqlConnection GetMySqlConnection()
        {
            try
            {
                conn = new MySqlConnection(cadenaConexion);
                conn.Open();

                MessageBox.Show("Conexión OK"); // TEST

                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR CONEXIÓN: " + ex.Message);
                return null;
            }
        }

    }
}