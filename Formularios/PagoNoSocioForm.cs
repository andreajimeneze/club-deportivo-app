using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Servicios;
using System;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class PagoNoSocio : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ListadosMaestrosServ servicio;
        private readonly Cliente _noSocio;

        public PagoNoSocioForm(ConexionMySql conexion) {
            _conexion = conexion;
        }
        public PagoNoSocioForm(Cliente noSocio, ConexionMySql conexion)
        {
            InitializeComponent();
            _noSocio = noSocio;
            _conexion = conexion;
           
            ConceptoPagoRepo repo = new ListadosMaestrosRepo(_conexion);
            servicio = new ListadosMaestrosServ(repo);
            
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy")}";
        }

        private void CargarActividades()
        {
            var lista = servicio.ObtenerActividades();

            lista.Insert(0, new Actividad
            {
                Id = 0,
                Nombre = "Seleccione actividad"
            });

            cbActividades.DataSource = lista;
            cbActividades.DisplayMember = "Nombre";
            cbActividades.ValueMember = "Id";
        }

        private void CargarMetodosPago()
        {
            var lista = servicio.ObtenerMetodosPago();

            lista.Insert(0, new MetodoPago
            {
                Id = 0,
                Nombre = "Seleccione método"
            });

            cbMetodosPago.DataSource = lista;
            cbMetodosPago.DisplayMember = "Nombre";
            cbMetodosPago.ValueMember = "Id";
        }
        private void PagoActividadForm_Load(object sender, EventArgs e)
        {
            CargarActividades();
            CargarMetodosPago();
            
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
    }
}
