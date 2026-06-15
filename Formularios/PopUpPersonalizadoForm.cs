using System;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class PopUpPersonalizadoForm : Form
    {
     
        public PopUpPersonalizadoForm(string titulo, string mensaje, string textoBtn)
        {
            InitializeComponent();
            lblTitulo.Text = titulo;
            lblMensaje.Text = mensaje;
            btnAccion.Text = textoBtn;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
