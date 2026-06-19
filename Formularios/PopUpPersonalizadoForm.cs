using System;
using System.Drawing;
using System.Drawing.Printing;
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
            this.Refresh();

            Bitmap captura = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(captura, new Rectangle(0, 0, this.Width, this.Height));

            PrintDocument doc = new PrintDocument();
            doc.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawImage(captura, ev.MarginBounds.Left, ev.MarginBounds.Top,
                                       ev.MarginBounds.Width, ev.MarginBounds.Height);
            };

            PrintDialog dialogo = new PrintDialog { Document = doc };
            if (dialogo.ShowDialog(this) == DialogResult.OK)
                doc.Print();


            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
