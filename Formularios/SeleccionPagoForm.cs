using System;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class SeleccionPagoForm : Form
    {
        private readonly ConexionMySql _conexion;
        public SeleccionPagoForm(ConexionMySql conexion)
        {
            _conexion = conexion;
            InitializeComponent();
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

        private void btnSocio_Click(object sender, EventArgs e)
        {
            PagoSocioForm pagoSocio = new PagoSocioForm(_conexion);
            pagoSocio.ShowDialog();
            this.Close();
        }

        private void btnNoSocio_Click(object sender, EventArgs e)
        {
            PagoNoSocioForm pagoActividad = new PagoActividadForm(_conexion);
            pagoActividad.ShowDialog();
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
