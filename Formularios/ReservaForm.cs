using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Models;
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
        private readonly SocioServ socioServ;

        public ReservaForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;

            ActividadRepo actRepo = new ActividadRepo(_conexion);
            ProgramacionRepo progRepo = new ProgramacionRepo(_conexion);
            SocioRepo socioRepo = new SocioRepo(_conexion);
            listasServ = new ListadosMaestrosServ(actRepo);
            progServ = new ProgramacionServ(progRepo);
            socioServ = new SocioServ(socioRepo);

            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy")}";
        }

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

        private void btnReserva_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;

            if (String.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Debe ingresar un DNI");
                return;
            }

            ClienteDTO clienteBuscado = socioServ.BuscarClientePorDni(dni);

            if (clienteBuscado == null)
            {
                MessageBox.Show("Cliente no existe, verifique el número de DNI");
                return;
            }

            lblNombre.Text = $"Nombre: {clienteBuscado.Nombre}";
            lblApellido.Text = $"Apellido: {clienteBuscado.Apellido}";
            lblDniSocio.Text = $"DNI: {clienteBuscado.Dni}";
            lblEsSocio.Text = $"Tipo Cliente: {(clienteBuscado.EsSocio ? "Socio" : "No Socio")}";

            if (clienteBuscado.EsSocio)
            {                            
                lblEstado.Text = $"Estado: {(clienteBuscado.Estado ? "Activo" : "Inactivo")}";
                
                MessageBox.Show("Cliente es socio");

                if(!clienteBuscado.Estado)
                {
                    MessageBox.Show("Socio se encuentra inactivo no puede realizar reserva.");
                } else
                {
                    
                    MessageBox.Show("Reserva efectuada exitosamente. Socio no debe pagar");

                    // Ejecutar reserva
                    // Debiera entregarse un comprobante de reserva
                }


                this.Close();

            } else
            {
                MessageBox.Show("Cliente NO ES SOCIO");
                PagoNoSocioForm pagoNoSocio = new PagoNoSocioForm(_conexion);
                this.Hide();
                pagoNoSocio.ShowDialog();
                this.Close();
                // Reserva se ejecuta cuando el no socio realiza el pago en PagoNoSocioForm
                // Pago no socio debiera llevar los datos del no socio y de la reserva para 
                // cargar datos por defecto?

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

        private void cbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActividades.SelectedItem is Actividad actividad && actividad.Id != 0)
            {
                CargarProgramacion(actividad.Id);
                lblActividad.Text = $"Actividad: {actividad.Nombre}";
                lblPrecio.Text = $"Precio: {actividad.Precio}";
            }
        }

        private void cbFechaHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFechaHora.SelectedItem is Programacion programacion && programacion.Id != 0)
            {
                lblFechaHora.Text = $"Fecha y Hora: {programacion.FormatoFechaHora()}";
                lblDisponibilidad.Text = $"{(programacion.EstaDisponible() ? "Disponibilidad: Sí" : "Disponibilidad: No")}";
            }
        }
    }
}
