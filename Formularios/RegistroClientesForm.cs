using ClubDeportivoApp.Formularios;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositories;
using ClubDeportivoApp.Services;
using System;
using System.Windows.Forms;

namespace ClubDeportivoApp.Forms
{
    public partial class RegistroClientesForm : Form
    {
        private readonly ConexionMySql _conexion;
        private string nombre;
        private string apellido;
        private string dni;
        private readonly RegistroServ servicio;
        public RegistroClientesForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
            RegistroRepo repo = new RegistroRepo(_conexion);
            servicio = new RegistroServ(repo);
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

 
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "" || txtApellido.Text == "" || txtDni.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos para poder realizar el registro");
                return;
            }

            if (!rbSocio.Checked && !rbNoSocio.Checked)
            {
                MessageBox.Show(
                    "Debe seleccionar si el cliente será socio o no socio."
                );

                return;
            }

            if (cbAptoFisico == null )
            {
                MessageBox.Show("No puede acceder a los servicios hasta que no presente el documento");
            }

            nombre = txtNombre.Text.Trim();
            apellido = txtApellido.Text.Trim();
            dni = txtDni.Text.Trim();
            bool esSocio = rbSocio.Checked;
            bool aptoFisico = cbAptoFisico.Checked;

            try { 
               int id = servicio.RealizarRegistro(nombre, apellido, dni, aptoFisico, esSocio);

            
               
                if(esSocio)
                {
                    int idSocio = servicio.AsignarTipoSocio(id, esSocio);
                    Cliente socio = new Cliente(nombre, apellido, dni);
                    MessageBox.Show($"Registro de CLIENTE SOCIO N° {idSocio}: {socio.Nombre}{socio.Apellido} exitoso");
                    FormalizacionSocioForm inscripcionSocio = new FormalizacionSocioForm(socio, idSocio,_conexion);
                    // AsignarTipoSocio debiera retornar al socio para poder setear el estado en caso de que no haya
                    // presentado el aptoFisico --- Puede continuar con la formalización y pago de cuota.
                    //Pregunta: dónde presenta aptoFísico nuevamente?
                    this.Hide();
                    inscripcionSocio.ShowDialog();
                    this.Close();
                } else
                {
                    int idSocio = servicio.AsignarTipoSocio(id, esSocio);
                    Cliente noSocio = new Cliente(nombre, apellido, dni);
                    MessageBox.Show($"Registro de CLIENTE NO SOCIO {noSocio.Nombre}{noSocio.Apellido} exitoso");
                    // AsignarTipoSocio debiera retornar al socio para poder setear el accesoDiario en caso de que no haya
                    // presentado el aptoFisico --- No puede reservar. Fin del proceso. Pregunta: dónde presenta aptoFísico nuevamente?
                    ReservaForm reserva = new ReservaForm(_conexion);
                    this.Hide();
                    reserva.ShowDialog();
                    this.Close();
                    LimpiarFormulario();
                }
               
            } catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Error");
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
