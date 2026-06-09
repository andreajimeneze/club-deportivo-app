using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Models;
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
        private int idReserva;
        ReservaDTO reserva = new ReservaDTO();


        public PagoNoSocioForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
       
            ConceptoPagoRepo cPagoRepo = new ConceptoPagoRepo(_conexion);
            MetodoPagoRepo mPagoRepo = new MetodoPagoRepo(_conexion);
            ReservaRepo reservRepo = new ReservaRepo(_conexion);
            PagosRepo pagoRepo = new PagosRepo(_conexion);
            servicio = new ListadosMaestrosServ(cPagoRepo, mPagoRepo);
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
        private void PagoNoSocioForm_Load(object sender, EventArgs e)
        {
            CargarMetodosPago();
            CargarConceptosPago();
            
        }

        private void btnValidarReserva_Click(object sender, EventArgs e)
        {
            idReserva = Convert.ToInt32(txtReserva.Text);

            reserva = resServ.BuscarReservaPorId(idReserva);

            if (reserva == null)
            {
                MessageBox.Show("Reserva no existe. Verifique el número ingresado");
                return;
            }

            lblNombre.Text = $"Nombre: {reserva.NombreCliente}";
            lblApellido.Text = $"Apellido: {reserva.ApellidoCliente}";
            lblDniSocio.Text = $"DNI: {reserva.Dni}";

            lblActividad.Text = $"Actividad: {reserva.Actividad}";
            lblFechaHora.Text = $"Fecha y Hora: {Convert.ToString(reserva.FechaHora)}";
            lblMonto.Text = $"Monto a Pagar: {Convert.ToString(reserva.Precio)}";

            lblFechaPago.Text = $"Fecha Pago: {Convert.ToString(DateTime.Now)}";
            lblMetodoPago.Text = $"Método Pago: {Convert.ToString(cbMetodosPago.ValueMember)}";
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

            bool result = pagoServ.RegistrarPagoActividad(reserva.IdCliente, idReserva, montoPago, reserva.Precio, conceptoPagoId, metodoPagoId);

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

        
    }
}
