using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class AccesoBDForm : Form
    {
        public AccesoBDForm()
        {
            InitializeComponent();
           
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtServidor.Text == "" || txtBD.Text == "" || txtUsuario.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos para poder acceder a la base de datos");
                return;
            }

            try
            {
                ConexionMySql conexion = new ConexionMySql();
                conexion.Server = txtServidor.Text.Trim();
                conexion.Database = txtBD.Text.Trim();
                conexion.Username = txtUsuario.Text.Trim();
                conexion.Password = txtPass.Text.Trim();

                

                MySqlConnection conn = conexion.GetMySqlConnection();

                
                if(conn == null)
                {
                    MessageBox.Show("Error de datos. No se estableció la conexión");
                    return;
                }

                this.Hide();
                LoginForm login = new LoginForm(conexion);
                login.Show();
                
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AccesoBDForm_Load(object sender, EventArgs e)
        {

        }
    }
}
