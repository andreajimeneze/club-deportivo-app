using ClubDeportivoApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Repositories
{
    internal class UsuarioRepository
    {
        private string _conexionDatabase;

        public UsuarioRepository(string conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public Usuario LoginRepository(string username, string password)
        {
            Usuario usuario = new Usuario();

            using (var conn = new MySqlConnection(_conexionDatabase))
            {
                conn.Open();

                string query = @"SELECT u.id, r.nombre FROM usuarios u JOIN roles r ON r.id = u.rol_id WHERE u.username = @username AND u.password = @password";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using(var reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            usuario.Id = reader.GetInt32("id");
                            usuario.RolId = reader.GetInt32("rolId");
                        }
                    }
                }
            }
            return usuario;
        } 
    }
}
