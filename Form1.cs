using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace ClubDeportivoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUsername_keyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_keyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLogin_click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;database=club_deportivo;user=root;password=condor28;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MessageBox.Show("Conexión exitosa");
            }
        }
    }
}
