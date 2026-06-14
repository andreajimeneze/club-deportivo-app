using ClubDeportivoApp.Documentos;
using ClubDeportivoApp.DTOS;
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
        private string dni;
        private int idActividad;
        private ReservaDTO reserva = new ReservaDTO();
        string mensaje;


        public PagoNoSocioForm(ConexionMySql conexion, int idReserva = 0)
        {
            InitializeComponent();
            _conexion = conexion;

            ConceptoPagoRepo cPagoRepo = new ConceptoPagoRepo(_conexion);
            MetodoPagoRepo mPagoRepo = new MetodoPagoRepo(_conexion);
            ActividadRepo actRepo = new ActividadRepo(_conexion);
            ReservaRepo reservRepo = new ReservaRepo(_conexion);
            PagosRepo pagoRepo = new PagosRepo(_conexion);
            servicio = new ListadosMaestrosServ(cPagoRepo, mPagoRepo, actRepo);
            resServ = new ReservaServ(reservRepo);
            pagoServ = new PagoActividad(pagoRepo);
            
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy")}";
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
            // Búsqueda por reserva: Si el campo id reserva no está vacío, busca por id.
            if(!string.IsNullOrWhiteSpace(txtReserva.Text))
            {
                int idRes = Convert.ToInt32(txtReserva.Text);
                reserva = resServ.BuscarReservaPendientePagoPorId(idRes); 
            } else
            {
                dni = txtDni.Text.Trim();
                // Validación 1: Si dni es nulo
                if(string.IsNullOrEmpty(dni)) {
                    MessageBox.Show("Debe ingresar un DNI");
                    return;
                }
                // Validación 2: Si dni tiene letras u otros caracteres
                if (!int.TryParse(txtDni.Text, out _))
                {
                    MessageBox.Show("Dni debe contener solo números");
                    return;
                }

                idActividad = Convert.ToInt32(cbActividades.SelectedValue);
                
                reserva = resServ.BuscarReservaPorDniYActividad(dni, idActividad);              
            }

            // Validación 3: Si la reserva es nula
            if (reserva == null)
            {
                MessageBox.Show("Reserva no existe. Verifique la información ingresada");
                return;
            }
            MostrarDatosReserva();
        }
        
        private void btnValidarPago_Click(object sender, EventArgs e)
        {
            // Validación 4: Si campo monto se deja vacío
            if (string.IsNullOrEmpty(txtMontoPago.Text))
            {
                MessageBox.Show("Debe ingresar un monto");
                return;
            }
            // Validación 5: Si se ingresan caracteres distintos a numéricos
            if (!Decimal.TryParse(txtMontoPago.Text, out _)) {
                MessageBox.Show("Ingrese un monto válido");
                return;
            }

            decimal montoPago = Convert.ToDecimal(txtMontoPago.Text);
            int metodoPagoId = int.Parse(cbMetodosPago.SelectedValue.ToString());
            int conceptoPagoId = int.Parse(cbConceptoPago.SelectedValue.ToString());
                      
            // Validación 6: Si no se realiza selección en combobox 
            if (cbMetodosPago.SelectedIndex == 0 || cbConceptoPago.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar método y concepto de pago");
                return;
            }

            
           
            var resultado = pagoServ.RegistrarPago(reserva, montoPago, conceptoPagoId, metodoPagoId);

            if (!resultado.Ok)
            {
                MessageBox.Show(resultado.mensaje);
                return;
            }

            MessageBox.Show("Pago registrado con éxito");
            MostrarComprobantePago();
          
            this.Hide();
            DashboardForm dashboard = new DashboardForm();
            this.Close();
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

        private void MostrarComprobantePago()
        {
            // Datos para ventana emergente
            string titulo = "Comprobante de Pago";
            string mensaje = GeneradorComprobantes.MostrarComprobantePagoActividad(reserva, cbMetodosPago.Text);
            string textoBtn = "Imprimir";

            PopUpPersonalizadoForm emergente = new PopUpPersonalizadoForm(titulo, mensaje, textoBtn);
            emergente.ShowDialog();
        }

        private void MostrarDatosReserva()
        {
            string titulo = "Datos Reserva";
            string mensaje = GeneradorComprobantes.MostrarComprobantePagoActividad(reserva, cbMetodosPago.Text);
            string textoBtn = "Aceptar";

            PopUpPersonalizadoForm emergente = new PopUpPersonalizadoForm(titulo, mensaje, textoBtn);
            emergente.ShowDialog();
        }
    }
}
