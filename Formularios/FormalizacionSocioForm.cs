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
        private readonly Cliente _socio;
        private decimal montoCuota;
        private int _idSocio;
     
        private readonly InscripcionSocioServ servicio;
        public FormalizacionSocioForm(Cliente socio, int idSocio, ConexionMySql conexion)
        {
            InitializeComponent();
            _socio = socio;
            _idSocio = idSocio;
            _conexion = conexion;

            PagosRepo repo = new PagosRepo(_conexion);
            servicio = new InscripcionSocioServ(repo);

            lblNombre.Text = socio.Nombre;
            lblApellido.Text = socio.Apellido;
            lblDni.Text = socio.Dni;
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            montoCuota = decimal.Parse(txtMontoCuota.Text);
            int diaPago = DateTime.Today.Day;
            string carpeta = @"C:\Contratos";        

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(carpeta, "ContratoSocio.pdf");

            GeneradorContrato.GenerarContrato(
                _socio.Nombre,
                _socio.Apellido,
                _socio.Dni,
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
            servicio.FormalizarSocio(_idSocio, montoCuota);
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
