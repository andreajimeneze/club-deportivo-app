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
    public partial class LoginForm : Form
    {
       // Atributos de la clase Form
        private LoginService service;
        private ConexionMySql conexion;
        private int intentosFallidos = 0;
        private const int maxIntentos = 3;

        // Constructor del formulario.
        // 1. Inicializa los componentes gráficos del formulario.
        // 2. Instancia el objeto de conexión a la base de datos.
        // 3. Crea el repositorio de usuarios, al que se le pasa la conexión.
        // 4. Crea el servicio de usuarios, al que se le pasa el repositorio.
        // De esta forma se implementa la inyección de dependencias entre capas.
        public LoginForm()
        {
            InitializeComponent();          
            conexion = new ConexionMySql();
            LoginRepository repository = new LoginRepository(conexion);
            service = new LoginService(repository);
        }

        private void txtUsername_keyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_keyPress(object sender, KeyPressEventArgs e)
        {

        }
        // Botón login ejecuta la lógica del login.
        // 1. Toma los datos ingresados por el usuario
        // a través de txtUsername (name del elemento) y usa método Trim() para eliminar espacios
        // que por error se introduzcan.
        // 2. Se llama al método Login y se le pasan los argumentos username y password.
        // 3. Se valida si se ingresan con los datos correctos (usuario != null), se instancia el objeto
        // dashboard con el usuario; se abre el dashboard y se oculta la pantalla de login.
        // 4. De lo contrario, se muestra mensaje de credenciales incorrectas. 
        // Usuario tiene 3 intentos (Formulario tiene atributo maxIntentos e intentosFallidos que hace de contador.
        // Al tercer intento fallido, se envía mensaje de máximo de intentos y la pantalla login se cierra.
        private void btnLogin_click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

           Usuario usuario = service.Login(username, password);

            if(usuario != null)
            {
                Dashboard dashboard = new Dashboard(usuario);
                
                dashboard.Show();
                this.Hide();
            }
            else
            {
                intentosFallidos++;
                MessageBox.Show("Credenciales no válidas. Intente nuevamente", 
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
