using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using ClubDeportivoApp;
using ClubDeportivoApp.Models;
using ClubDeportivoApp.Services;
using ClubDeportivoApp.Repositories;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace ClubDeportivoApp
{
    public partial class Form1 : Form
    {
       
        private UsuarioService service;
        private ConexionMySql conexion;
        private int intentosFallidos = 0;
        private const int maxIntentos = 3;

     
        public Form1()
        {
            InitializeComponent();
            conexion = new ConexionMySql();
            UsuarioRepository repository = new UsuarioRepository(conexion);
            service = new UsuarioService(repository);
        }

        private void txtUsername_keyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_keyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLogin_click(object sender, EventArgs e)
        {
            var repo = new UsuarioRepository(new ConexionMySql());
            var service = new UsuarioService(repo);

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

           Usuario usuario = service.LoginService(username, password);

            if(usuario != null)
            {
                Dashboard dashboard = new Dashboard(usuario);
                
                dashboard.Show();
                this.Hide();
            }
            else
            {
                intentosFallidos++;
                MessageBox.Show("Credenciales no válidas", 
                    "Error de login", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);  
                
                if(intentosFallidos >= maxIntentos)
                {
                    MessageBox.Show("Ha superado el límite de intentos permitidos",
                        "Acceso bloqueado",
                        MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.Hide();
                }
            }


        }
    }
}
