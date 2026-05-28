using ClubDeportivoApp.Repositories;
using ClubDeportivoApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoApp.Forms
{
    public partial class Registro : Form
    {
        protected string nombre;
        protected string apellido;
        protected string dni;
        internal InscripcionService servicio;
        public Registro()
        {
            InitializeComponent();
            ConexionMySql conexion = new ConexionMySql();
            InscripcionRepository repo = new InscripcionRepository(conexion);
            servicio = new InscripcionService(repo);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text.Trim();
            apellido = txtApellido.Text.Trim();
            dni = txtDni.Text.Trim();
            bool esSocio = rbSocio.Checked;

            servicio.realizarRegistro(nombre, apellido, dni, esSocio);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
