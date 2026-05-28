using ClubDeportivoApp.Repositories;
using ClubDeportivoApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoApp.Forms
{
    public partial class Registro : Form
    {
        internal string nombre;
        internal string apellido;
        internal string dni;
        internal RegistroServ servicio;
        public Registro()
        {
            InitializeComponent();
            ConexionMySql conexion = new ConexionMySql();
            RegistroRepo repo = new RegistroRepo(conexion);
            servicio = new RegistroServ(repo);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text.Trim();
            apellido = txtApellido.Text.Trim();
            dni = txtDni.Text.Trim();
            bool esSocio = rbSocio.Checked;
            bool aptoFisico = cbAptoFisico.Checked;

            try { 
               servicio.realizarRegistro(nombre, apellido, dni, aptoFisico, esSocio);

               MessageBox.Show("Registro exitoso");
               this.Hide();
            } catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Error");
            }

            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbAptoFisico_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
