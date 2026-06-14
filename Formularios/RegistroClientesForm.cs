using ClubDeportivoApp.Formularios;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositories;
using ClubDeportivoApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClubDeportivoApp.Forms
{
    public partial class RegistroClientesForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ClienteServ servicio;
           
        public RegistroClientesForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
            ClienteRepo repo = new ClienteRepo(_conexion);
            servicio = new ClienteServ(repo);
        
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

 
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validación 1: los campos del formulario son obligatorios.
            if(txtNombre.Text == "" || txtApellido.Text == "" || txtDni.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos para poder realizar el registro");
                return;
            }

            // Validación 2: Dni debe contener solo campos numéricos.
            if(!int.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("Dni debe contener solo números");
                return;
            }

            // Validación 3: Nombre y apellido no deben contener números:
            if(txtNombre.Text.Any(char.IsDigit) || txtApellido.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Nombre y apellido no deben contener números");
                return;
            }

            // Validación 4: Debe seleccionar si será socio o no socio
            if (!rbSocio.Checked && !rbNoSocio.Checked)
            {
                MessageBox.Show(
                    "Debe seleccionar si el cliente será socio o no socio."
                );

                return;
            }

           // Campos ingresados en formulario se guardan en variables
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();
            bool QuiereSerSocio = rbSocio.Checked;
            bool aptoFisico = cbAptoFisico.Checked;

            try {

                Cliente cliente;

                if (rbSocio.Checked)
                {
                    cliente = new Socio(nombre, apellido, dni, aptoFisico);
                }
                else
                {
                    cliente = new NoSocio(nombre, apellido, dni, aptoFisico);
                }
                // Se realiza registro de cliente: Socio / No socio
                var registrado = servicio.RealizarRegistro(cliente, QuiereSerSocio);
               

                if (!registrado.Ok)
                {
                    MessageBox.Show(registrado.mensaje);
                    return;
                }

                MessageBox.Show($"Registro de CLIENTE {(registrado.cliente is Socio ? "SOCIO" : "NO SOCIO")} N° {registrado.cliente.IdCliente}: {registrado.cliente.Nombre} {registrado.cliente.Apellido} exitoso");
                
                if (QuiereSerSocio)
                {
                    FormalizacionSocioForm inscripcionSocio = new FormalizacionSocioForm(registrado.cliente, _conexion);
                    this.Hide();
                    inscripcionSocio.ShowDialog();
                    this.Close();
                } else
                {
                    this.Close();
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
