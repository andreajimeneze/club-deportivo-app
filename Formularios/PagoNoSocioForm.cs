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
        private readonly PagoServ pagoServ;
        private  int _idReserva;
        private string dni;
        private int idActividad;
        private ReservaDTO reserva = new ReservaDTO();


        public PagoNoSocioForm(ConexionMySql conexion, int idReserva = 0)
        {
            InitializeComponent();
            _conexion = conexion;
            _idReserva = idReserva;

            ConceptoPagoRepo cPagoRepo = new ConceptoPagoRepo(_conexion);
            MetodoPagoRepo mPagoRepo = new MetodoPagoRepo(_conexion);
            ActividadRepo actRepo = new ActividadRepo(_conexion);
            ReservaRepo reservRepo = new ReservaRepo(_conexion);
            PagosRepo pagoRepo = new PagosRepo(_conexion);
            servicio = new ListadosMaestrosServ(cPagoRepo, mPagoRepo, actRepo);
            resServ = new ReservaServ(reservRepo);
            pagoServ = new PagoServ(pagoRepo);
            
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy")}";
        }

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
            // Búsqueda por reserva
            if(!string.IsNullOrWhiteSpace(txtReserva.Text))
            {
                int idRes = Convert.ToInt32(txtReserva.Text);
                reserva = resServ.BuscarReservaPorId(idRes);  
            } else
            {
                dni = txtDni.Text.Trim();
                if(string.IsNullOrEmpty(dni)) {
                    MessageBox.Show("Debe ingresar un DNI");
                    return;
                }
                if (!int.TryParse(txtDni.Text, out _))
                {
                    MessageBox.Show("Dni debe contener solo números");
                    return;
                }
                idActividad = Convert.ToInt32(cbActividades.SelectedValue);
                MessageBox.Show("id actividad: " + idActividad);
                MessageBox.Show("dni: " + dni);

                reserva = resServ.BuscarReservaPorDniYActividad(dni, idActividad);              
            }

            if (reserva == null)
            {
                MessageBox.Show("Reserva no existe. Verifique la información ingresada");
                return;
            }


            string mensaje =
            $"Nombre: {reserva.NombreCliente}\n" +
            $"Apellido: {reserva.ApellidoCliente}\n" +
            $"DNI: {reserva.Dni}\n" +
            $"Actividad: {reserva.Actividad}\n" +
            $"Fecha y Hora: {Convert.ToString(reserva.FechaHora)}\n" +
            $"Monto a Pagar: {Convert.ToString(reserva.Precio)}\n";
            //+
            //$"Fecha Pago: {Convert.ToString(DateTime.Now)}" +
            //$"Método Pago: {Convert.ToString(cbMetodosPago.ValueMember)}";

            PopUpPersonalizadoForm emergente = new PopUpPersonalizadoForm("Datos Reserva: ", mensaje);
            emergente.ShowDialog();
        }
        
        private void btnValidarPago_Click(object sender, EventArgs e)
        {
            decimal montoPago = Convert.ToDecimal(txtMontoPago.Text);
            int metodoPagoId = int.Parse(cbMetodosPago.SelectedValue.ToString());
            int conceptoPagoId = int.Parse(cbConceptoPago.SelectedValue.ToString());

           
            if (cbMetodosPago.SelectedIndex == 0 || cbConceptoPago.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar método y concepto de pago");
                return;
            }

            bool result = pagoServ.RegistrarPagoActividad(reserva.IdCliente, _idReserva, montoPago, reserva.Precio, conceptoPagoId, metodoPagoId);

            if (result)
            {
                MessageBox.Show("Pago realizado con éxito");
                //Falta imprimir comprobante pago
                this.Hide();
                DashboardForm dashboard = new DashboardForm();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al ejecutar el pago");
            }
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

        private void lblFechaHoy_Click(object sender, EventArgs e)
        {

        }
    }
}
