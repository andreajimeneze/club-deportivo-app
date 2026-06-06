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
    public partial class SeleccionPagoForm : Form
    {
        public SeleccionPagoForm()
        {
            InitializeComponent();
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaHoy_Click(object sender, EventArgs e)
        {

        }
    }
}
