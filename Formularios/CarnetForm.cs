using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Repositories;
using ClubDeportivoApp.Services;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Helpers;
using ClubDeportivoApp.Models;

namespace ClubDeportivoApp.Formularios
{

    public partial class CarnetForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ClienteServ _clienteServ;
        private Cliente _socioActual;

        public CarnetForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
            var clienteRepo = new ClienteRepo(conexion);
            _clienteServ = new ClienteServ(clienteRepo);
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Debe ingresar un DNI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(dni, out _))
            {
                MessageBox.Show("El DNI debe contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cliente = _clienteServ.BuscarClientePorDni(dni);
            if (cliente == null || !(cliente is Socio))
            {
                MessageBox.Show("No se encontró un socio activo con ese DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarPanelDatos();
                btnImprimirCarnet.Enabled = false;
                return;
            }

            _socioActual = cliente;
            lblNombreValor.Text = cliente.Nombre;
            lblApellidoValor.Text = cliente.Apellido;
            lblDniValor.Text = cliente.Dni;
            if(cliente is Socio socio)
            lblEstadoValor.Text = socio.Estado ? "Activo" : "Inactivo";
            btnImprimirCarnet.Enabled = true;
        }

        private void LimpiarPanelDatos()
        {
            lblNombreValor.Text = "-------";
            lblApellidoValor.Text = "-------";
            lblDniValor.Text = "-------";
            lblEstadoValor.Text = "-------";
        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            if (_socioActual == null)
            {
                MessageBox.Show("Primero debe buscar un socio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CarnetsClub");
                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string archivo = Path.Combine(carpeta, $"Carnet_{_socioActual.Dni}.pdf");
                GenerarPdfCarnet(_socioActual, archivo);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(archivo) { UseShellExecute = true });
                MessageBox.Show($"Carnet generado correctamente en:\n{archivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el carnet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarPdfCarnet(Cliente socio, string ruta)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // Dimensiones tarjeta de crédito: 85.6 mm x 53.98 mm
            // En puntos (1 mm = 2.83465 puntos) -> 85.6 * 2.83465 ≈ 242.7 pt, 53.98 * 2.83465 ≈ 153 pt
            float anchoMm = 85.6f;
            float altoMm = 53.98f;
            float anchoPt = anchoMm * 2.83465f;
            float altoPt = altoMm * 2.83465f;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(anchoPt, altoPt);
                    page.Margin(5); // márgenes internos pequeños
                    page.Background(QuestPDF.Helpers.Colors.Grey.Lighten1);

                    page.Content()
                        .Border(1) // borde negro fino
                        .BorderColor(QuestPDF.Helpers.Colors.Blue.Medium)
                        .Padding(5)
                        .Column(col =>
                        {
                            col.Spacing(2);

                            // Línea superior: "Sistema de Gestión" (pequeño, centrado)
                            col.Item().AlignCenter().Text("Carnet de Socio").FontSize(10).Bold();

                            // Título principal "CLUB" (negrita, grande)
                            col.Item().AlignCenter().Text(@"CLUB DEPORTIVO ESTRELLA DEL SUR").FontSize(12).Bold();

                            // Espacio
                            col.Item().Height(32);
                            bool estaActivo = socio is Socio s && s.Estado;
                            // Datos del socio
                            col.Item().AlignCenter().Text($"Nombre: {socio.Nombre.ToUpper()} {socio.Apellido.ToUpper()}").FontSize(9).Bold();
                            col.Item().AlignCenter().Text($"DNI: {socio.Dni}").FontSize(9).Bold();
                            col.Item().AlignCenter().Text($"Estado: {(estaActivo ? "SOCIO ACTIVO" : "SOCIO INACTIVO")}").FontSize(9).Bold().FontColor(estaActivo ? QuestPDF.Helpers.Colors.Black : QuestPDF.Helpers.Colors.Black);

                            // Espacio
                            col.Item().Height(10);

                            // Pie: texto "Sistema de Gestión" pequeño o logo
                            //col.Item().AlignCenter().Text("Sistema de Gestión").FontSize(7).FontColor(QuestPDF.Helpers.Colors.Black);
                        });
                });
            }).GeneratePdf(ruta);
        }

        private void btnVolver_Click(object sender, EventArgs e) => this.Close();
        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
      
        private void CarnetForm_Load(object sender, EventArgs e)
        {
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now:dd/MM/yyyy HH:mm}";
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
