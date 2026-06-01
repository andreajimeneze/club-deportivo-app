using ClubDeportivoApp.Modelos;
using System;
using System.Windows.Forms;
using ClubDeportivoApp.Servicios;
using ClubDeportivoApp.Repositorios;


namespace ClubDeportivoApp.Formularios
{
    public partial class InscripcionSocio : Form
    {
        private ListadosMaestrosServ servicio;
        private InscripcionSocioServ inscripcionServ;
        private int socioId;
        public InscripcionSocio(int socioId)
        {
            InitializeComponent();
            ConexionMySql conexion = new ConexionMySql();
            ListadosMaestrosRepo repo = new ListadosMaestrosRepo(conexion);
            servicio = new ListadosMaestrosServ(repo);
            InscripcionSocioRepo inscripcionRepo = new InscripcionSocioRepo(conexion);
            inscripcionServ = new InscripcionSocioServ(inscripcionRepo);
            this.socioId = socioId;
        }

        private void CargarMetodosPago()
        {
            var lista = servicio.ObtenerMetodosPago();

            lista.Insert(0, new MetodoPago
            {
                Id = 0,
                Nombre = "Seleccione método pago"
            });

            cbMedioPago.DataSource = lista;
            cbMedioPago.DisplayMember = "Nombre";
            cbMedioPago.ValueMember = "Id";
        }

        private void CargarConceptosPago()
        {
            var lista = servicio.ObtenerConceptosPago();

            lista.Insert(0, new ConceptoPago
            {
                Id = 0,
                Nombre = "Seleccione concepto pago"
            });

            cbConceptoPago.DataSource = lista;
            cbConceptoPago.DisplayMember = "Nombre";
            cbConceptoPago.ValueMember = "Id";
        }
        private void InscripcionSocio_Load(object sender, EventArgs e)
        {
            CargarConceptosPago();
            CargarMetodosPago();

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnValidarPago_Click(object sender, EventArgs e)
        {
           
            decimal monto;
            try
            {
                if (!decimal.TryParse(txtMontoPago.Text, out monto))
                {
                    MessageBox.Show("Ingrese un monto válido");
                    return;
                }

                int metodoPagoId = int.Parse(cbMedioPago.SelectedValue.ToString());
                int conceptoPagoId = int.Parse(cbConceptoPago.SelectedValue.ToString());

                bool result = inscripcionServ.FormalizarInscripcion(socioId, monto, conceptoPagoId, metodoPagoId);

                if (result)
                {
                    MessageBox.Show("Inscripción realizada con éxito");
                }
                else
                {
                    MessageBox.Show("Error al realizar la inscripción");
                }

            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
