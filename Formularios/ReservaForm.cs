using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Servicios;
using System;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class ReservaForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly Cliente _noSocio;
        private readonly ListadosMaestrosServ listasServ;
        public ReservaForm(ConexionMySql conexion) {
            _conexion = conexion;
        }
        public ReservaForm(Cliente noSocio, ConexionMySql conexion)
        {
            InitializeComponent();
            _noSocio = noSocio;
            _conexion = conexion;
           
            ActividadRepo actRepo = new ActividadRepo(_conexion);
            ConceptoPagoRepo cPagoRepo = new ConceptoPagoRepo(_conexion);
            MetodoPagoRepo mPagoRepo = new MetodoPagoRepo(_conexion);
            listasServ = new ListadosMaestrosServ(actRepo);
            
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy")}";
        }

        private void CargarActividades()
        {
            var lista = listasServ.ObtenerActividades();

            lista.Insert(0, new Actividad
            {
                Id = 0,
                Nombre = "Seleccione actividad"
            });

            cbActividades.DataSource = lista;
            cbActividades.DisplayMember = "Nombre";
            cbActividades.ValueMember = "Id";
        }

        private void btnValidarPago_Click(object sender, EventArgs e)
        {

        }

        private void btnReserva_Click(object sender, EventArgs e)
        {

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

        private void ReservaForm_Load(object sender, EventArgs e)
        {
            CargarActividades();
        }

        private void cbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtActividad_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
