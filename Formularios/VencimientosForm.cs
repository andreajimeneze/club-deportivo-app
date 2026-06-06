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
    }
}
