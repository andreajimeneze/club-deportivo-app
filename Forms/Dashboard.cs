using ClubDeportivoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoApp
{
    public partial class Dashboard : Form
    {
        internal Usuario Usuario { get; set; }

        public Dashboard(Usuario usuario)
        {
            InitializeComponent();
            this.Usuario = usuario;
            labelUsuario.Text = $"Bienvenido, {usuario.Username}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCarnet_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {

        }

        private void btnMorosos_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
