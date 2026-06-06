using ClubDeportivoApp.Forms;
using ClubDeportivoApp.Formularios;
using ClubDeportivoApp.Models;
using System;
using System.Windows.Forms;

namespace ClubDeportivoApp
{
    public partial class DashboardForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly Usuario _usuario;

        public DashboardForm(Usuario usuario, ConexionMySql conexion)
        {
            _usuario = usuario;
            _conexion = conexion;
            InitializeComponent();
            // Aplica método por herencia de Persona
            lblUsuario.Text = $"Bienvenido, {usuario.MostrarNombreCompleto()} ({usuario.Rol.Nombre})";
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

       
        private void btnRegistro_Click(object sender, EventArgs e)
        {

            RegistroClientesForm registro = new RegistroClientesForm(_conexion);
            this.Hide();
            registro.ShowDialog();
            this.Show();         
        }

        private void btnCarnet_Click(object sender, EventArgs e)
        {
            PagoCarnetForm pagoCarnet = new PagoCarnetForm(_conexion);
            this.Hide();
            pagoCarnet.ShowDialog();
            this.Show();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            PagosForm pagos = new PagosForm(_conexion);
            this.Hide();
            pagos.ShowDialog();
            this.Show();
        }

        private void btnMorosos_Click(object sender, EventArgs e)
        {
            VencimientosForm vencimientos = new VencimientosForm(_conexion);
            this.Hide();
            vencimientos.ShowDialog();
            this.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
