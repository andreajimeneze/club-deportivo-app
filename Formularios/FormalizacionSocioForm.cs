using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Forms;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Servicios;
using ClubDeportivoApp.Utilidades;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class FormalizacionSocioForm : Form
    {
        private readonly ConexionMySql _conexion;
        private Cliente _nuevoSocio;
        private Cuota cuota;
        private int montoCuota;
     
        private readonly InscripcionSocioServ servicio;

        public FormalizacionSocioForm(Cliente nuevoSocio, ConexionMySql conexion)
        {
            InitializeComponent();
            _nuevoSocio = nuevoSocio;
            _conexion = conexion;
    
            InscripcionRepo repo = new InscripcionRepo(_conexion);
            servicio = new InscripcionSocioServ(repo);

            lblNombre.Text = _nuevoSocio.Nombre;
            lblApellido.Text = _nuevoSocio.Apellido;
            lblDni.Text = _nuevoSocio.Dni;
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(!Decimal.TryParse(txtMontoCuota.Text, out _)) {
                MessageBox.Show("Ingrese un monto válido");
                return;
            }
            
            montoCuota = Convert.ToInt32(txtMontoCuota.Text);
            
            int diaPago = DateTime.Today.Day;
            string carpeta = @"C:\Contratos";        

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(carpeta, "ContratoSocio.pdf");

            GeneradorContrato.GenerarContrato(
                _nuevoSocio.Nombre,
                _nuevoSocio.Apellido,
                _nuevoSocio.Dni,
                montoCuota,
                diaPago,
                ruta
            );

            Process.Start(new ProcessStartInfo()
            {
                FileName = ruta,
                UseShellExecute = true
            });

            btnAceptarContrato.Enabled = true;
        }

        private void btnAceptarContrato_Click(object sender, EventArgs e)
        {
            cuota = new Cuota(montoCuota);
            
            var resultado = servicio.FormalizarSocio(_nuevoSocio, cuota);
            
           if (!resultado.Ok)
            {
                MessageBox.Show(resultado.mensaje);
                return;
            }
            
            PagoSocioForm pagoSocio = new PagoSocioForm(_conexion);
            this.Hide();
            pagoSocio.ShowDialog();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DashboardForm dashboard = new DashboardForm();
            this.Close();
            dashboard.Show();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            RegistroClientesForm registroClientes = new RegistroClientesForm(_conexion);
            this.Hide();
            registroClientes.ShowDialog();
            this.Close();
        }
    }
}
