using ClubDeportivoApp.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClubDeportivoApp.Repositories
{
    internal class UsuarioRepository
    {
        private readonly ConexionMySql _conexionDatabase;

        public UsuarioRepository(
            ConexionMySql conexionDatabase
        )
        {
            _conexionDatabase = conexionDatabase;
        }

        public Usuario LoginRepository(
            string username,
            string password
        )
        {
            Usuario usuario = null;

            using (
                MySqlConnection conn =
                _conexionDatabase.GetMySqlConnection()
            )
            {
                using (
                    MySqlCommand cmd =
                    new MySqlCommand("LoginUsuario", conn)
                )
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "p_username",
                        username
                    );

                    cmd.Parameters.AddWithValue(
                        "p_password",
                        password
                    );

                    using (
                        MySqlDataReader reader =
                        cmd.ExecuteReader()
                    )
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario();

                            usuario.Id =
                                reader.GetInt32("id");

                            usuario.Username =
                                reader.GetString("username");

                            usuario.RolId =
                                reader.GetInt32("rol_id");

                            usuario.Activo =
                                reader.GetBoolean("activo");
                        }
                    }
                }
                return usuario;
            }
        }
    }
}