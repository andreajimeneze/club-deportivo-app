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
    public partial class PagosForm : Form
    {
        private readonly ConexionMySql _conexion;
        public PagosForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
        }

        private void btnValidarPago_Click(object sender, EventArgs e)
        {

        }
    }
}
