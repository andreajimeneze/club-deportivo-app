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
    public partial class PagoNoSocioForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ListadosMaestrosServ servicio;
        private readonly ReservaServ resServ;
        private readonly PagoActividad pagoServ;
        private ReservaDTO reserva = new ReservaDTO();
        private int _idActividad;
   


        public PagoNoSocioForm(ConexionMySql conexion, int idActividad = 0)
        {
            InitializeComponent();
            _conexion = conexion;
            _idActividad = idActividad;
            ConceptoPagoRepo cPagoRepo = new ConceptoPagoRepo(_conexion);
            MetodoPagoRepo mPagoRepo = new MetodoPagoRepo(_conexion);
            ActividadRepo actRepo = new ActividadRepo(_conexion);
            ReservaRepo reservRepo = new ReservaRepo(_conexion);
            PagosRepo pagoRepo = new PagosRepo(_conexion);
            servicio = new ListadosMaestrosServ(cPagoRepo, mPagoRepo, actRepo);
            resServ = new ReservaServ(reservRepo);
            pagoServ = new PagoActividad(pagoRepo);
            
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
            txtMontoPago.Enabled = false;
            cbConceptoPago.Enabled = false;
            cbMetodosPago.Enabled = false;
            btnConfirmarPago.Enabled = false;
        }

        // Carga de métodos de pago
        private void CargarMetodosPago()
        {
            var lista = servicio.ObtenerMetodosPago();

            lista.Insert(0, new MetodoPago
            {
                Id = 0,
                Nombre = "Seleccione método pago"
            });

            cbMetodosPago.DataSource = lista;
            cbMetodosPago.DisplayMember = "Nombre";
            cbMetodosPago.ValueMember = "Id";
        }

        // Carga de conceptos de pago
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

        // Carga de actividades
        private void CargarActividades()
        {
            var lista = servicio.ObtenerActividades();

            lista.Insert(0, new Actividad
            {
                Id = 0,
                Nombre = "Seleccione actividad"
            });

            cbActividades.DataSource = lista;
            cbActividades.DisplayMember = "Nombre";
            cbActividades.ValueMember = "Id";
        }

        private void PagoNoSocioForm_Load(object sender, EventArgs e)
        {
            CargarMetodosPago();
            CargarConceptosPago();
            CargarActividades();
            
        }

        private void btnValidarReserva_Click(object sender, EventArgs e)
        {
            (bool Ok, string mensaje, ReservaDTO reserva) resultado;

            // Búsqueda por reserva: Si el campo id reserva no está vacío, busca por id.
            // De lo contrario, busca por DNI

            bool esReserva = !string.IsNullOrWhiteSpace(txtReserva.Text.Trim());
            bool esDni = !string.IsNullOrWhiteSpace(txtDni.Text.Trim());

            if(esReserva && esDni)
            {
                MessageBox.Show("Debe ingresar nro de reserva o de dni, no ambos");
                return;
            }

            if (!esReserva && !esDni)
            {
                MessageBox.Show("Debe ingresar uno de los dos campos");
                return;
            }
            if (esReserva)
            {
                //txtDni.Enabled = false;
                //cbActividades.Enabled = false;

                if(!ValidacionDatos.SoloNumeros(txtReserva.Text.Trim(), out string mensaje))
                {
                    MessageBox.Show(mensaje);
                    return;
                }

                int idRes = Convert.ToInt32(txtReserva.Text.Trim());
                resultado = resServ.BuscarReservaPendientePagoPorId(idRes);

                txtDni.Text = resultado.reserva.Dni;
                cbActividades.Text = resultado.reserva.Actividad;
            } else
            {
                //txtDni.Enabled = true;
                //cbActividades.Enabled = true;

                string dni = txtDni.Text.Trim();
                // Validación 1: Valida DNI con helper
                if (!ValidacionDatos.ValidarDni(dni, out string mensaje))
                {
                    MessageBox.Show(mensaje);
                    return;
                }

                if (cbActividades.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe seleccionar una actividad");
                    return;
                }

                _idActividad = Convert.ToInt32(cbActividades.SelectedValue);
                
                resultado = resServ.BuscarReservaPendientePorDniYActividad(dni, _idActividad);

                txtReserva.Text = Convert.ToString(resultado.reserva.IdReserva);
                cbActividades.Text = resultado.reserva.Actividad;
            }

            if (!resultado.Ok)
            {
                MessageBox.Show(resultado.mensaje);
                return;
            }

            reserva = resultado.reserva;

            txtMontoPago.Text = reserva.Precio.ToString();
            txtMontoPago.ReadOnly = true;
            cbConceptoPago.Enabled = true;
            cbMetodosPago.Enabled = true;
            btnConfirmarPago.Enabled = true;

            MessageBox.Show(resultado.mensaje);
        }
        
        private void btnValidarPago_Click(object sender, EventArgs e)
        {      

            decimal montoPago = Convert.ToDecimal(txtMontoPago.Text);
            int metodoPagoId = int.Parse(cbMetodosPago.SelectedValue.ToString());
            int conceptoPagoId = int.Parse(cbConceptoPago.SelectedValue.ToString());
                      
            // Validación 6: Si no se realiza selección en combobox 
            if (cbMetodosPago.SelectedIndex == 0 || cbConceptoPago.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar método y concepto de pago");
                return;
            }

            // Registra pago           
            var resultado = pagoServ.RegistrarPago(reserva, montoPago, conceptoPagoId, metodoPagoId);

            if (!resultado.Ok)
            {
                MessageBox.Show(resultado.mensaje);
                return;
            }


            MessageBox.Show(resultado.mensaje);

            MostrarComprobantePago();
          
            //this.Hide();
            //this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReservaForm reserva = new ReservaForm(_conexion);
            reserva.ShowDialog();
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

        private void MostrarComprobantePago()
        {
            // Datos para ventana emergente
            string titulo = "Comprobante de Pago";
            string mensaje = GeneradorComprobantes.MostrarComprobantePagoActividad(reserva, cbMetodosPago.Text);
            string textoBtn = "Imprimir";

            PopUpPersonalizadoForm emergente = new PopUpPersonalizadoForm(titulo, mensaje, textoBtn);
            emergente.ShowDialog();
        }
    }
}
