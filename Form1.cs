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
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string resultado = service.LoginService(username, password);

            MessageBox.Show(resultado);            
        }
    }
}
