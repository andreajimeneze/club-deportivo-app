using ClubDeportivoApp.Modelos;
using System;
using System.Windows.Forms;
using ClubDeportivoApp.Servicios;
using ClubDeportivoApp.Repositorios;
using System.Runtime.CompilerServices;
using ClubDeportivoApp.DTOS;


namespace ClubDeportivoApp.Formularios
{
    public partial class PagoSocioForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ListadosMaestrosServ servicio;
        private readonly SocioServ socioServ;
        private readonly PagoServ pagoServ;
        private CuotaPendienteDTO cuota;


          public PagoSocioForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;

            ConceptoPagoRepo cPagoRepo = new ConceptoPagoRepo(_conexion);
            MetodoPagoRepo mPagoRepo = new MetodoPagoRepo(_conexion);
            servicio = new ListadosMaestrosServ(cPagoRepo, mPagoRepo);
            SocioRepo socioRepo = new SocioRepo(_conexion);
            socioServ = new SocioServ(socioRepo);
            PagosRepo pagosRepo = new PagosRepo(_conexion);
            pagoServ = new PagoServ(pagosRepo);

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


        private void btnValidarCuota_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (String.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Debe ingresar un DNI");
                return;
            }

            ClienteDTO clienteBuscado = socioServ.BuscarClientePorDni(dni);

            if(clienteBuscado == null)
            {
                MessageBox.Show("Cliente no existe, verifique el número de DNI");
                return;
            }

            if(!clienteBuscado.EsSocio)
            {
                MessageBox.Show("Cliente no es socio");
                return;
            }

            cuota = new CuotaPendienteDTO();
            cuota = socioServ.ObtenerCuotaPendienteServ(dni);


            cuota = socioServ.ObtenerCuotaPendienteServ(dni);

            if (cuota != null)
            {
                txtMontoPago.Enabled = true;
                cbConceptoPago.Enabled = true;
                cbMedioPago.Enabled = true;
                btnValidarPago.Enabled = true;
            }

            if (cuota == null)
            {
                MessageBox.Show("Socio no tiene cuota pendiente");
                return;
            }

            txtNombre.Text = $"Nombres:   {cuota.Nombre}";
            txtApellido.Text = $"Apellidos:  {cuota.Apellido}";
            txtDniSocio.Text = $"DNI:    {cuota.Dni}";
            txtCuota.Text = $"Cuota: {Convert.ToString(cuota.MontoCuota)}";
            txtEstado.Text = $"Estado socio: {(cuota.EstadoSocio == true ? "Activo" : "Inactivo")}";
            txtFechaVencimiento.Text = $"Vencimiento: {Convert.ToString(cuota.FechaVencimiento)}";
        }

        private void btnValidarPago_Click(object sender, EventArgs e)
        {
            if (cuota == null)
            {
                MessageBox.Show($"Primero debe validar el socio {cuota.IdSocio}");
                return;
            }

            // 2. Validar combos
            if (cbMedioPago.SelectedIndex == 0 || cbConceptoPago.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar método y concepto de pago");
                return;
            }

            decimal montoAPagar = Convert.ToDecimal(txtMontoPago.Text);
            int metodoPagoId = int.Parse(cbMedioPago.SelectedValue.ToString());
            int conceptoPagoId = int.Parse(cbConceptoPago.SelectedValue.ToString());
            try
            {
               
                bool result = pagoServ.RegistrarPago(cuota.IdSocio, null, montoAPagar, cuota.MontoCuota, conceptoPagoId, metodoPagoId);

                if (result)
                {
                    MessageBox.Show("Pago realizado con éxito");
                }
                else
                {
                    MessageBox.Show("Error al ejecutar el pago");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
