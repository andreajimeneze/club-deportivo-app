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
    public partial class ReservaForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ListadosMaestrosServ listasServ;
        private readonly ProgramacionServ progServ;
        private readonly ReservaServ resServ;
        private readonly ClienteServ cliServ;
        private Actividad actividad;
        private Programacion programacion;
        private ReservaDTO reserva;
        private Cliente clienteBuscado;


        public ReservaForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;

            ActividadRepo actRepo = new ActividadRepo(_conexion);
            ProgramacionRepo progRepo = new ProgramacionRepo(_conexion);
            CuotaRepo socioRepo = new CuotaRepo(_conexion);
            ReservaRepo resRepo = new ReservaRepo(_conexion);
            ClienteRepo cliRepo = new ClienteRepo(_conexion);
            listasServ = new ListadosMaestrosServ(actRepo);
            progServ = new ProgramacionServ(progRepo);
            resServ = new ReservaServ(resRepo);
            cliServ = new ClienteServ(cliRepo);

            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

        // Carga actividades en combobox
        private void CargarActividades()
        {
            var lista = listasServ.ObtenerActividades();

            lista.Insert(0, new Actividad
            {
                Id = 0,
                Nombre = "Seleccione actividad"
            });

            cbActividades.DataSource = lista;
            cbActividades.DisplayMember = "Nombre";
            cbActividades.ValueMember = "Id";
        }

        // Carga programación por idActividad en combobox
        private void CargarProgramacion(int idActividad)
        {
            var lista = progServ.ObtenerProgramacionPorActividad(idActividad);

            lista.Insert(0, new Programacion
            {
                Id = 0,
                FechaHora = DateTime.MinValue,
                CuposDisponibles = 0
            });

            cbFechaHora.DataSource = null;
            cbFechaHora.DataSource = lista;
            cbFechaHora.DisplayMember = $"Descripcion";
            cbFechaHora.ValueMember = "Id";

            lblFechaHora.Text = "Fecha y Hora:";
            lblDisponibilidad.Text = "Disponibilidad:";
        }

        // Carga nombre de actividad asociada a programación, en combobox
        private void cbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActividades.SelectedItem is Actividad act && act.Id != 0)
            {
                actividad = act;
                CargarProgramacion(act.Id);
                lblActividad.Text = $"Actividad: {act.Nombre}";
                lblPrecio.Text = $"Precio: {act.Precio}";
            }
        }
               
        // Carga fecha y hora de actividad asociada a programación, en combobox
        private void cbFechaHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFechaHora.SelectedItem is Programacion prog && prog.Id != 0)
            {
                programacion = prog;
                lblFechaHora.Text = $"Fecha y Hora: {prog.FormatoFechaHora()}";
                lblDisponibilidad.Text = $"{(prog.EstaDisponible() ? "Disponibilidad: Sí" : "Disponibilidad: No")}";
            }
        }

        private void btnValidarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            // Valida DNI con helper
            if(!ValidacionDatos.ValidarDni(dni, out string mensaje))
            {
                MessageBox.Show(mensaje);
                return;
            }
            // Busca cliente por dni
            clienteBuscado = cliServ.BuscarClientePorDni(dni);

            // Validación 4: Si cliente viene nulo
            if (clienteBuscado == null)
            {
                MessageBox.Show("Cliente no existe, verifique el número de DNI");
                return;
            }
            
            // Imprime datos del cliente en label de formulario (para verificación visual de datos)
            lblNombre.Text = $"Nombre: {clienteBuscado.Nombre}";
            lblApellido.Text = $"Apellido: {clienteBuscado.Apellido}";
            lblDniSocio.Text = $"DNI: {clienteBuscado.Dni}";

            if (clienteBuscado is Socio socio)
            {
                lblEsSocio.Text = "Tipo Cliente: Socio";
                lblEstado.Text = $"Estado Cliente: {(socio.Estado ? "Activo" : "Inactivo")}";
            }
            else
            {
                lblEsSocio.Text = "Tipo Cliente: No Socio";
                lblEstado.Text = "Estado Cliente: N/A";
            }
            lblAptoFisico.Text = $"Apto Fisico: {(clienteBuscado.AptoFisico ? "SÍ" : "NO")}";

         // Validación 5: Si cliente no puede reservar
            // Además da posibilidad de que presente el documento en ese momento para poder reservar.
            if (!clienteBuscado.PuedeReservar())
            {
                MessageBox.Show("Cliente no ha presentado certificado de Apto Físico");
                DialogResult respuesta = MessageBox.Show(
                    "¿Cliente realiza entrega de certificado válido?",
                    "Presentar certificado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    cliServ.ActualizarAptoFisico(clienteBuscado);
                    clienteBuscado = cliServ.BuscarClientePorDni(dni);
                    lblAptoFisico.Text = $"Apto Fisico: {(clienteBuscado.AptoFisico ? "SÍ" : "NO")}";
                    //MessageBox.Show("Debe validar cliente nuevamente");
                }

                return;
            }
}
private void btnReserva_Click(object sender, EventArgs e)
        {
            // Validaciones antes de llamar al servicio
            if (clienteBuscado == null)
            {
                MessageBox.Show("Debe validar el cliente primero.");
                return;
            }

         
            if (actividad == null || actividad.Id == 0)
            {
                MessageBox.Show("Debe seleccionar una actividad.");
                return;
            }

            if (programacion == null || programacion.Id == 0)
            {
                MessageBox.Show("Debe seleccionar una fecha y hora.");
                return;
            }

            // Aplica método generar reserva
            var resultado = resServ.GenerarReserva(actividad, clienteBuscado, programacion);

            // Envía menssaje según el caso (validaciones en el método)
             MessageBox.Show(resultado.mensaje);
           
            if (!resultado.Ok)
            {
                txtDni.Clear();
                  return;                           
            }

            // Se guarda item 3 de retorno de método GenerarReserva en variable reserva
            reserva = resultado.reserva;

            // Se muestra el comprobante de reserva
            MostrarComprobanteReserva();

            if (clienteBuscado is Socio)
            {
                this.Close();
            } else 
            { 
                PagoNoSocioForm pagoNoSocio = new PagoNoSocioForm(_conexion, reserva.IdReserva);
                this.Hide();
                pagoNoSocio.ShowDialog();
                this.Close();
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

        private void ReservaForm_Load(object sender, EventArgs e)
        {
            CargarActividades();
        }

        
        private void MostrarComprobanteReserva()
        {
            // Datos para ventana emergente
            string titulo = "Datos Reserva";
            string mensaje = GeneradorComprobantes.MostrarComprobanteReserva(reserva);
            string textoBtn = "Imprimir";

            PopUpPersonalizadoForm emergente = new PopUpPersonalizadoForm(titulo, mensaje, textoBtn);
            emergente.ShowDialog();
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            bool validaTexto = !string.IsNullOrEmpty(txtDni.Text.Trim()) && txtDni.Text.Length == 8;
            cbActividades.Enabled = validaTexto;
            cbFechaHora.Enabled = validaTexto;
            btnConfirmarReserva.Enabled = validaTexto;
            lblNombre.Text = "Nombre:";
            lblApellido.Text = "Apellido:";
            lblDniSocio.Text = "DNI:";
            lblEsSocio.Text = "Tipo Cliente:";
            lblEstado.Text = "Estado Cliente:";
            lblAptoFisico.Text = "Apto Físico:";
            lblActividad.Text = "Actividad:";
            lblPrecio.Text = "Precio:";
            lblFechaHora.Text = "Fecha y Hora:";
            lblDisponibilidad.Text = "Disponibilidad:";

            actividad = null;
            programacion = null;
            reserva = null;

        }
    }
}
