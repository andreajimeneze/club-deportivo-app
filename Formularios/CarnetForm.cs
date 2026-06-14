using System;
using System.IO;
using System.Windows.Forms;
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Documentos;
using ClubDeportivoApp.Servicios;
using ClubDeportivoApp.Repositorios;

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
                
                // Llama a GeneradorCarnet clase estática
                GeneradorCarnet.GenerarPdfCarnet(_socioActual, archivo);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(archivo) { UseShellExecute = true });
                MessageBox.Show($"Carnet generado correctamente en:\n{archivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el carnet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
