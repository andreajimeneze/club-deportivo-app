using ClubDeportivoApp.Formularios;
using ClubDeportivoApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClubDeportivoApp
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AccesoBDForm());
        }
    }
}
