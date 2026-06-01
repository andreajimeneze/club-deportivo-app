using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class InscripcionNoSocioForm : Form
    {
        private ListadosMaestrosServ servicio;
        private int idSocio;
        public InscripcionNoSocioForm(int idSocio)
        {
            InitializeComponent();
            ConexionMySql conn = new ConexionMySql();
            ListadosMaestrosRepo repo = new ListadosMaestrosRepo(conn);
            servicio = new ListadosMaestrosServ(repo);
            this.idSocio = idSocio;
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

            cbMetodos.DataSource = lista;
            cbMetodos.DisplayMember = "Nombre";
            cbMetodos.ValueMember = "Id";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarActividades();
            CargarMetodosPago();
            
        }
        private void cbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cbMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
