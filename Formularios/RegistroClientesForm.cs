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
        internal string nombre;
        internal string apellido;
        internal string dni;
        internal RegistroServ servicio;
        public RegistroClientesForm()
        {
            InitializeComponent();
            ConexionMySql conexion = new ConexionMySql();
            RegistroRepo repo = new RegistroRepo(conexion);
            servicio = new RegistroServ(repo);
            lblFechaHoy.Text = $"Fecha y hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";
        }
  
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text.Trim();
            apellido = txtApellido.Text.Trim();
            dni = txtDni.Text.Trim();
            bool esSocio = rbSocio.Checked;
            bool aptoFisico = cbAptoFisico.Checked;

            try { 
               int id = servicio.realizarRegistro(nombre, apellido, dni, aptoFisico, esSocio);

               MessageBox.Show("Registro exitoso");
                if(esSocio)
                {
                    Cliente socio = new Cliente(nombre, apellido, dni);
                    InscripcionSocioForm inscripcionSocio = new InscripcionSocioForm(socio, id);
                    inscripcionSocio.Show();
                    this.Close();
                } else
                {
                    Cliente noSocio = new Cliente(nombre, apellido, dni);
                    InscripcionNoSocioForm inscripcionNoSocio = new InscripcionNoSocioForm(noSocio);
                    inscripcionNoSocio.Show();
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
    }
}
