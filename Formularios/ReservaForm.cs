using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositories;
using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Services;
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
        private readonly CuotaServ socioServ;
        private readonly ReservaServ resServ;
        private readonly ClienteServ cliServ;
        private Actividad actividad;
        private Programacion programacion;

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
            socioServ = new CuotaServ(socioRepo);
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
            ClienteDTO clienteBuscado = cliServ.BuscarClientePorDni(dni);

            // Validación 3: Si cliente viene nulo

            if (clienteBuscado == null)
            {
                MessageBox.Show("Cliente no existe, verifique el número de DNI");
                return;
            }

            // Validación 4: Si cliente no cuenta con aptoFísico
            if(!clienteBuscado.AptoFisico)
            {
                MessageBox.Show("Cliente no tiene apto físico, por lo que no puede acceder a servicios");
                return;
            }

            // Imprime datos del cliente en label de formulario
            lblNombre.Text = $"Nombre: {clienteBuscado.Nombre}";
            lblApellido.Text = $"Apellido: {clienteBuscado.Apellido}";
            lblDniSocio.Text = $"DNI: {clienteBuscado.Dni}";
            lblEsSocio.Text = $"Tipo Cliente: {(clienteBuscado.EsSocio ? "Socio" : "No Socio")}";

            
            if (clienteBuscado.EsSocio)
            {                            
                lblEstado.Text = $"EstadoReserva: {(clienteBuscado.Estado ? "Activo" : "Inactivo")}";
                
                MessageBox.Show("Cliente ES SOCIO");
                // Validación 5: Si cliente es socio, verificar si está activo o inactivo
                if (!clienteBuscado.Estado)
                {
                    MessageBox.Show("Socio se encuentra inactivo no puede realizar reserva.");
                    return;
                } else
                {
                    MessageBox.Show("Reserva efectuada exitosamente. Socio no debe pagar");
                   

                    // Se genera la reserva como autorizada (socio no paga) y se descuenta cupo en programación
                    int idReserva = resServ.GenerarReserva(actividad.Id, clienteBuscado.IdCliente, programacion.FechaHora);
                    // Validación 6: Si idReserva es 0 o negativo, hubo error al crear la reserva       
                    
                    
                    if(idReserva <= 0)
                    {
                        MessageBox.Show("Error al crear la reserva");
                        return;
                    }

                    // Falta imprimir comprobante
                }


                this.Close();

            } else
            {
                MessageBox.Show("Cliente NO ES SOCIO. Debe pagar por la actividad.");
                MessageBox.Show("actividad id: " + actividad.Id);
                MessageBox.Show("programación fecha: " + programacion.FechaHora);
                MessageBox.Show("cliente id: " + clienteBuscado.IdCliente);
                // Se genera la reserva como Pendiente de Pago (no socio paga). Programación no descuenta cupo hasta que se efectúa el pago
                int idReserva = resServ.GenerarReserva(actividad.Id, clienteBuscado.IdCliente, programacion.FechaHora);
                // Validación 6b: Si idReserva es 0 o negativo, hubo error al crear la reserva
                if (idReserva <= 0)
                {
                    MessageBox.Show("Error al crear la reserva");
                    return;
                }
                MessageBox.Show("Reserva creada con éxito");
                // Se deriva a no socio al formulario de pago de la actividad. Se traspasa idReserva
                PagoNoSocioForm pagoNoSocio = new PagoNoSocioForm(_conexion, idReserva);
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

        
    }
}
