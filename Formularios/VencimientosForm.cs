using System;
using System.Data;
using System.Windows.Forms;
using ClubDeportivoApp.Repositorios;

namespace ClubDeportivoApp.Formularios
{
    public partial class VencimientosForm : Form
    {
        private readonly ConexionMySql _conexion;
        private VencimientoRepo _vencimientoRepo;

        public VencimientosForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
            _vencimientoRepo = new VencimientoRepo(conexion);
            lblFechaHoy.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            
            this.Load += VencimientosForm_Load;
            btnBuscarVencimientos.Click += btnBuscar_Click;

            
            dataGridView1.AutoGenerateColumns = true;
           
            dataGridView1.Columns.Clear();
        }

        private void VencimientosForm_Load(object sender, EventArgs e)
        {
            CargarVencimientos(DateTime.Today);
        }

        private void CargarVencimientos(DateTime fecha)
        {
            try
            {
                DataTable dt = _vencimientoRepo.ObtenerVencimientosPorFecha(fecha);
                dataGridView1.DataSource = dt;
                lblCantidad.Text = $"Total: {dt.Rows.Count} socios con vencimiento en {fecha:dd/MM/yyyy}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar vencimientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value;
            CargarVencimientos(fecha);
        }

        private void btnVolver_Click(object sender, EventArgs e) => this.Close();
        private void btnMinimizar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}
