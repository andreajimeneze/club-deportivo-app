using ClubDeportivoApp.Documentos;
using ClubDeportivoApp.DTOS;
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

            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy")}";
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
        private void btnReserva_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;

            // Validación 1: Dni no puede venir vacío
            if (String.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Debe ingresar un DNI");
                return;
            }
            // Validación 2: Dni debe contener solo números
            if(!int.TryParse(dni, out _))
            {
                MessageBox.Show("DNI debe contener solo números");
                return;
            }
            // Busca cliente por dni
            Cliente clienteBuscado = cliServ.BuscarClientePorDni(dni);

            // Validación 3: Si cliente viene nulo

            if (clienteBuscado == null)
            {
                MessageBox.Show("Cliente no existe, verifique el número de DNI");
                return;
            }

            if(!clienteBuscado.PuedeReservar())
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
                    return;
                }

                return;
            }

            // Imprime datos del cliente en label de formulario
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

            var resultado = resServ.GenerarReserva(actividad, clienteBuscado, programacion);

            MessageBox.Show(resultado.mensaje);

            LimpiarFormulario();
            
            if(!resultado.Ok)
            {
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

        private void LimpiarFormulario()
        {
            // TextBox
            txtDni.Clear();

            // Labels cliente
            lblNombre.Text = "Nombre:";
            lblApellido.Text = "Apellido:";
            lblDniSocio.Text = "DNI:";
            lblEsSocio.Text = "Tipo Cliente:";
            lblEstado.Text = "Estado Cliente:";
            lblAptoFisico.Text = "Apto Físico:";

            // Labels actividad
            lblActividad.Text = "Actividad:";
            lblPrecio.Text = "Precio:";
            lblFechaHora.Text = "Fecha y Hora:";
            lblDisponibilidad.Text = "Disponibilidad:";

            // Combos
            cbActividades.SelectedIndex = -1;
            cbFechaHora.DataSource = null;

            // Variables internas (MUY IMPORTANTE)
            actividad = null;
            programacion = null;
            reserva = null;
        }

    }
}
