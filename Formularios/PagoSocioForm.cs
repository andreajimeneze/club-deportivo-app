using ClubDeportivoApp.Documentos;
using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Helpers;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Servicios;
using System;
using System.Windows.Forms;


namespace ClubDeportivoApp.Formularios
{
    public partial class PagoSocioForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ListadosMaestrosServ servicio;
        private readonly ClienteServ clienteServ;
        private readonly CuotaServ cuotaServ;
        private readonly PagoCuota pagoServ;
        private CuotaDTO cuota;


          public PagoSocioForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;

            ConceptoPagoRepo cPagoRepo = new ConceptoPagoRepo(_conexion);
            MetodoPagoRepo mPagoRepo = new MetodoPagoRepo(_conexion);
            servicio = new ListadosMaestrosServ(cPagoRepo, mPagoRepo);
            ClienteRepo clienteRepo = new ClienteRepo(_conexion);
            CuotaRepo cuotaRepo = new CuotaRepo(_conexion);
            clienteServ = new ClienteServ(clienteRepo);
            PagosRepo pagosRepo = new PagosRepo(_conexion);
            pagoServ = new PagoCuota(pagosRepo);
            cuotaServ = new CuotaServ(cuotaRepo);

            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

        // Carga métodos de pago
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

        // Carga concepto de pago
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
        private void PagoSocioForm_Load(object sender, EventArgs e)
        {
            CargarConceptosPago();
            CargarMetodosPago();
        }


        private void btnValidarCuota_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            // Validación 1: Valida DNI con helper
            if (!ValidacionDatos.ValidarDni(dni, out string mensaje))
            {
                MessageBox.Show(mensaje);
                return;
            }
            // Busca cliente por dni
            var clienteBuscado = clienteServ.BuscarClientePorDni(dni);

            // Validación 2: cliente es nulo
            if(clienteBuscado == null)
            {
                MessageBox.Show("Cliente no existe, verifique el número de DNI");
                return;
            }

            if(clienteBuscado != null &&!(clienteBuscado is Socio) && !(clienteBuscado is NoSocio))
            {
                MessageBox.Show("Cliente no ha formalizado su inscripción como socio");
                DialogResult respuesta = MessageBox.Show(
                    "Socio no ha firmado el contrato.\n¿Desea formalizar la inscripción?",
                    "Formalizar inscripción",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

                if (respuesta == DialogResult.OK)
                {
                    using (FormalizacionSocioForm frm = new FormalizacionSocioForm(clienteBuscado, _conexion))
                    {
                        frm.ShowDialog();
                    }
                } else
                {
                    int idNoSocio = clienteServ.AsignarANoSocio(clienteBuscado);
                    MessageBox.Show("Cliente ha sido asignado como no socio");
                    this.Close();
                }               
            }

            cuota = new CuotaDTO();
            // Obtiene cuota pendiente más antigua
            cuota = cuotaServ.ObtenerCuotaPendienteServ(clienteBuscado.Dni);

            // Valiación 3: Si cuota no existe
            if (cuota == null)
            {

                MessageBox.Show("Socio no tiene cuota pendiente");
                btnValidarPago.Enabled = false;
                txtMontoPago.Enabled = false;
                cbConceptoPago.Enabled = false;
                cbMedioPago.Enabled = false;
                return;
            }

            // Validación 4: Si cuota existe, se activan campos para pago
            if (cuota != null)
            {
                txtMontoPago.Enabled = true;
                cbConceptoPago.Enabled = true;
                cbMedioPago.Enabled = true;
                btnValidarPago.Enabled = true;
            }

            txtNombre.Text = $"Nombres:   {cuota.Nombre}";
            txtApellido.Text = $"Apellidos:  {cuota.Apellido}";
            txtDniSocio.Text = $"DNI:    {cuota.Dni}";
            txtCuota.Text = $"Cuota: {Convert.ToString(cuota.MontoCuota)}";
            txtEstado.Text = $"EstadoReserva socio: {(cuota.EstadoSocio == true ? "Activo" : "Inactivo")}";
            txtFechaVencimiento.Text = $"Vencimiento: {Convert.ToString(cuota.FechaVencimiento)}";
        }

        private void btnValidarPago_Click(object sender, EventArgs e)
        {
            if (cuota == null)
            {
                MessageBox.Show($"Primero debe validar el socio");
                return;
            }

            // Validación 5: Valida combos
            if (cbMedioPago.SelectedIndex == 0 || cbConceptoPago.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar método y concepto de pago");
                return;
            }

            // Validación 6: Valida monto en helper
            if (!ValidacionDatos.ValidarMonto(txtMontoPago.Text.Trim(), out string mensaje))
            {
                MessageBox.Show(mensaje);
                return;
            }

            decimal montoAPagar = Convert.ToDecimal(txtMontoPago.Text);
            int metodoPagoId = int.Parse(cbMedioPago.SelectedValue.ToString());
            int conceptoPagoId = int.Parse(cbConceptoPago.SelectedValue.ToString());
            
            try
            {
               var resultado = pagoServ.RegistrarPago(cuota, montoAPagar, conceptoPagoId, metodoPagoId);

                if(!resultado.Ok)
                {
                    MessageBox.Show(resultado.mensaje);
                    return;
                }

                MessageBox.Show(resultado.mensaje);

                MostrarComprobantePago();

                // Si es la primera cuota (de inscripción) deriva al carnet
                if (conceptoPagoId == 1)
                {
                    this.Hide();
                    CarnetForm carnet = new CarnetForm(_conexion);
                    carnet.ShowDialog();
                    this.Close();
                    return;
                 }
                //Falta imprimir comprobante pago
                this.Hide();
                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
                this.Close();

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

        private void MostrarComprobantePago()
        {
            // Datos para ventana emergente
            string titulo = "Comprobante de Pago";
            string mensaje = GeneradorComprobantes.MostrarComprobantePagoCuota(cuota, cbMedioPago.Text);
            string textoBtn = "Imprimir";

            PopUpPersonalizadoForm emergente = new PopUpPersonalizadoForm(titulo, mensaje, textoBtn);
            emergente.ShowDialog();
        }
    }
}
