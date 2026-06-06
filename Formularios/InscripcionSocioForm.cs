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
    public partial class InscripcionSocioForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly Cliente _socio;
        private readonly int _idSocio;
        private decimal montoCuota;
        internal InscripcionSocioServ serv;
        public InscripcionSocioForm(Cliente socio, int idSocio, ConexionMySql conexion)
        {
            InitializeComponent();
            _socio = socio;
            _idSocio = idSocio;
            _conexion = conexion;

            PagosRepo repo = new PagosRepo(_conexion);
            serv = new InscripcionSocioServ(repo);
           
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

            PagoCarnetForm pagoSocio = new PagoCarnetForm(_idSocio, montoCuota, _conexion);
            

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

            pagoSocio.Show();
            this.Close();
        }
    }
}
