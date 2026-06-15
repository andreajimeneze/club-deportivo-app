using ClubDeportivoApp.Modelos;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClubDeportivoApp.Repositorios
{
    internal class LoginRepo
    {
        // Atributo de la clase. Necesario para la conexión a la DB
        private readonly ConexionMySql _conexionDatabase;

        // Se realiza inyección de dependencias para la conexión.
        public LoginRepo(
            ConexionMySql conexionDatabase
        )
        {
            _conexionDatabase = conexionDatabase;
        }

        // Método LoginRepo con retorno Usuario.
        // 1. Abre la conexión a la BD usando la clase ConexionMySql.
        // 2. Crea un comando para ejecutar el procedimiento almacenado "LoginUsuario".
        // 3. Agrega los parámetros username y password al comando.
        // 4. Ejecuta el procedimiento y obtiene los resultados con MySqlDataReader.
        // 5. Si se encuentra un registro, instancia un objeto Usuario y asigna sus propiedades.
        // 6. Retorna el objeto Usuario; si no hay coincidencia, retorna null.
        public Usuario LoguearUsuario(
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
                            usuario.Rol = new Rol();

                            usuario.Id =
                                reader.GetInt32("id");

                            usuario.Username =
                                reader.GetString("username");

                            usuario.Activo =
                                reader.GetBoolean("activo");
                            usuario.Nombre =
                                reader.GetString("nombre");

                            usuario.Apellido =
                                reader.GetString("apellido");

                            usuario.Rol.Nombre = reader.GetString("rol");
                        }
                    }
                }
                return usuario;
            }
        }
    }
}