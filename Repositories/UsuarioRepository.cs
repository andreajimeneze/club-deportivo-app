using ClubDeportivoApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ClubDeportivoApp;

namespace ClubDeportivoApp.Repositories
{
    internal class UsuarioRepository
    {
        private readonly ConexionMySql _conexionDatabase;

        public UsuarioRepository(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public Usuario LoginRepository(string username, string password)
        {
            Usuario usuario = null;

            using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {

                string query = @"SELECT u.username, u.rol_id FROM usuarios u JOIN roles r ON r.id = u.rol_id WHERE u.username = @username AND u.password = @password";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using(var reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            usuario = new Usuario();
                            usuario.Username = reader.GetString("username");
                            usuario.RolId = reader.GetInt32("rol_id");
                        }
                    }
                }
            }
            return usuario;
        } 
   
    }
}
