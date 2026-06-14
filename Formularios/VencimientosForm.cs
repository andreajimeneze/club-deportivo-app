using System;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class VencimientosForm : Form
    {
        private readonly ConexionMySql _conexion;
        public VencimientosForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
