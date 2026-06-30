using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClubDeportivoApp.Formularios
{
    public partial class NominaClientesForm : Form
    {
        private readonly ConexionMySql _conexion;
        private readonly ClienteServ servicio; 
        public NominaClientesForm(ConexionMySql conexion)
        {
            InitializeComponent();
            _conexion = conexion;
            ClienteRepo repo = new ClienteRepo(_conexion);
            servicio = new ClienteServ(repo);

            this.Load += NominaClientesForm_Load;
            btnBuscar_Click.Click += BtnBuscar_Click;

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.Columns.Clear();

            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }

        private void CargarClientes()
        {
            try
            {
                List<Cliente> clientes = servicio.BuscarClientes();
                MostrarClientePorDniOApellido(clientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MostrarClientePorDniOApellido(List<Cliente> clientes)
        {
            try {  
            dataGridView1.DataSource = clientes;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;

            if (clientes.Count == 0)
            {
                MessageBox.Show("No existen clientes actualmente");
            }

        }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim();

            List<Cliente> clientes = servicio.BuscarClientePorDniONombreOApellido(filtro);
            MostrarClientePorDniOApellido(clientes);
        }

        private void BtnLimpiarForm_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            CargarClientes();
        }

        private void NominaClientesForm_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
