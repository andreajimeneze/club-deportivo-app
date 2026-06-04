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
        private Cliente socio;
        private int idSocio;
        private decimal montoCuota;
        internal InscripcionSocioServ serv;
        public InscripcionSocioForm(Cliente socio, int idSocio)
        {
            InitializeComponent();
            ConexionMySql conexion = new ConexionMySql();
            PagosRepo repo = new PagosRepo(conexion);
            serv = new InscripcionSocioServ(repo);
            this.socio = socio;
            this.idSocio = idSocio;
            lblNombre.Text = socio.Nombre;
            lblApellido.Text = socio.Apellido;
            lblDni.Text = socio.Dni;
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PagoCarnetForm pagoSocio = new PagoCarnetForm(idSocio, montoCuota);
            montoCuota = decimal.Parse(txtMontoCuota.Text);
            int diaPago = DateTime.Today.Day;

            string carpeta = @"C:\Contratos";

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(carpeta, "ContratoSocio.pdf");

            GeneradorContrato.GenerarContrato(
                socio.Nombre,
                socio.Apellido,
                socio.Dni,
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
