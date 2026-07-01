using ClubDeportivoApp.Documentos;
using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class PagoNoSocioForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ListadosMaestrosServ maestrosServ;
        private readonly ReservaServ reservaServ;
        private readonly PagoActividad pagoServ;
        private List<ReservaDTO> reservasCliente = new List<ReservaDTO>();
        private ReservaDTO reserva;
        public PagoNoSocioForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
            ConceptoPagoRepo cPagoRepo = new ConceptoPagoRepo(_conexion);
            MetodoPagoRepo mPagoRepo = new MetodoPagoRepo(_conexion);
            ActividadRepo actRepo = new ActividadRepo(_conexion);
            maestrosServ = new ListadosMaestrosServ(cPagoRepo, mPagoRepo, actRepo);

            ReservaRepo resRepo = new ReservaRepo(_conexion);
            PagosRepo pagosRepo = new PagosRepo(_conexion);
            reservaServ = new ReservaServ(resRepo);
            pagoServ = new PagoActividad(pagosRepo);
        }

        // Carga de métodos de pago
        private void CargarMetodosPago()
        {
            var lista = maestrosServ.ObtenerMetodosPago();

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
            var lista = maestrosServ.ObtenerConceptosPago();

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
        private void CargarActividadesReservadas(List<ReservaDTO> reservas)
        {
            var actividadesReservadas = reservas
                .Select(r => r.Actividad)
                .Distinct()
                .OrderBy( a => a)
                .ToList();

            actividadesReservadas.Insert(0, "Seleccione actividad");
               
            cbActividades.DataSource = actividadesReservadas;          
        }

        private void ReservasForm2_Load(object sender, EventArgs e)
        {
            CargarConceptosPago();
            CargarMetodosPago();
        }

        private void btnValidarReserva_Click(object sender, EventArgs e)
        {
            string filtro = txtReserva.Text.Trim();

            var reservaBuscada = new ReservaDTO
            {
                Dni = filtro,
                IdReserva = int.TryParse(filtro, out int id) ? id : 0
            };

            var reservasEncontradas = reservaServ.BuscarReservasPendientesPorIdODni(reservaBuscada);

            if(!reservasEncontradas.Ok)
            {
                MessageBox.Show(reservasEncontradas.mensaje);
                LimpiarFormulario();
                return;
            }

            reservasCliente = reservasEncontradas.reservas;
            reserva = reservasCliente.FirstOrDefault();

            Cliente cliente = new Cliente(reserva.NombreCliente, reserva.ApellidoCliente, reserva.Dni);

            if (reservasEncontradas.Ok)
            {
                MessageBox.Show($"Reserva encontrada para cliente:\n  Nombre: {cliente.Nombre}\n Apellido:{cliente.Apellido}\n DNI: {cliente.Dni}");
                CargarActividadesReservadas(reservasCliente);     
            }
        }

        private void cbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string actividadSeleccionada = cbActividades.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(actividadSeleccionada) || actividadSeleccionada == "Seleccione actividad")
            {
                reserva = null;
                txtMontoPago.Text = "";
                return;
            }

            reserva = reservasCliente.FirstOrDefault(r => r.Actividad == actividadSeleccionada);
            txtMontoPago.Text = $"$ {reserva.Precio.ToString()}";
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            // Validación 6: Si no se realiza selección en combobox 
            if (cbMetodosPago.SelectedIndex == 0 || cbConceptoPago.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar método y concepto de pago");
                return;
            }

            if(reserva == null)
            {
                MessageBox.Show("Debe seleccionar una actividad");
                return;
            }

            decimal montoPago = reserva.Precio;
            int metodoPagoId = int.Parse(cbMetodosPago.SelectedValue.ToString());
            int conceptoPagoId = int.Parse(cbConceptoPago.SelectedValue.ToString());

            // Registra pago           
            var resultado = pagoServ.RegistrarPago(reserva, montoPago, conceptoPagoId, metodoPagoId);

            if (!resultado.Ok)
            {
                MessageBox.Show(resultado.mensaje);
                return;
            }
            MessageBox.Show(resultado.mensaje);

            MostrarComprobantePago();
            LimpiarFormulario();
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

        public void LimpiarFormulario()
        {
            txtReserva.Clear();
            txtMontoPago.Clear();
            cbActividades.SelectedItem = "Seleccione actividad";
        }
    }
}
