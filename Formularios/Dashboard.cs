using ClubDeportivoApp.Forms;
using ClubDeportivoApp.Formularios;
using ClubDeportivoApp.Models;
using System;
using System.Windows.Forms;

namespace ClubDeportivoApp
{
    public partial class Dashboard : Form
    {
        internal Usuario Usuario { get; set; }
        protected ConexionMySql _conexion;

        public Dashboard() { }
        public Dashboard(Usuario usuario)
        {
            InitializeComponent();
            this.Usuario = usuario;
            lblUsuario.Text = $"Bienvenido, {usuario.Username}";
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

       
        private void btnRegistro_Click(object sender, EventArgs e)
        {

            RegistroClientesForm registro = new RegistroClientesForm();
            this.Hide();
            registro.ShowDialog();
            this.Show();         
        }

        private void btnCarnet_Click(object sender, EventArgs e)
        {
            PagoCarnetForm pagoCarnet = new PagoCarnetForm();
            this.Hide();
            pagoCarnet.ShowDialog();
            this.Show();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            PagosForm pagos = new PagosForm();
            this.Hide();
            pagos.ShowDialog();
            this.Show();
        }

        private void btnMorosos_Click(object sender, EventArgs e)
        {
            VencimientosForm vencimientos = new VencimientosForm();
            this.Hide();
            vencimientos.ShowDialog();
            this.Show();
        }
    }
}
