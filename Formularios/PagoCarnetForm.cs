using ClubDeportivoApp.Modelos;
using System;
using System.Windows.Forms;
using ClubDeportivoApp.Servicios;
using ClubDeportivoApp.Repositorios;
using System.Runtime.CompilerServices;


namespace ClubDeportivoApp.Formularios
{
    public partial class PagoCarnetForm : Form
    {
        private ListadosMaestrosServ servicio;
        private InscripcionSocioServ inscripcionServ;
        private RegistroPagoServ pagoServ;
        private int idSocio;
        private decimal montoCuota;

        public PagoCarnetForm() { }
        public PagoCarnetForm(int idSocio, decimal montoCuota)
        {
            InitializeComponent();
            ConexionMySql conexion = new ConexionMySql();
            ListadosMaestrosRepo repo = new ListadosMaestrosRepo(conexion);
            servicio = new ListadosMaestrosServ(repo);
            PagosRepo inscripcionRepo = new PagosRepo(conexion);
            inscripcionServ = new InscripcionSocioServ(inscripcionRepo);
            pagoServ = new RegistroPagoServ(inscripcionRepo);
            this.idSocio = idSocio;
            this.montoCuota = montoCuota;
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
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

        private void btnValidarPago_Click(object sender, EventArgs e)
        {
            decimal montoAPagar = decimal.Parse(txtMontoPago.Text);
            int metodoPagoId = int.Parse(cbMedioPago.SelectedValue.ToString());
            int conceptoPagoId = int.Parse(cbConceptoPago.SelectedValue.ToString());
            try
            {
           
                bool result = pagoServ.RegistrarPago(idSocio,  null, montoAPagar, montoCuota, conceptoPagoId, metodoPagoId);

                if (result)
                {
                    MessageBox.Show("Pago realizado con éxito");
                }
                else
                {
                    MessageBox.Show("Error al realizar la inscripción");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {

        }
    }
}
