using ClubDeportivoApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ClubDeportivoApp.Repositories
{
    internal class InscripcionRepository
    {
        // Atributo de la clase. Necesario para la conexión a la DB
        private readonly ConexionMySql _conexionDatabase;

        // Se realiza inyección de dependencias para la conexión.
        public InscripcionRepository(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public int RegistrarPersona(string nombre, string apellido, string dni, bool esSocio)
        {
            using (
                MySqlConnection conn =
                _conexionDatabase.GetMySqlConnection()
            )
            {
                using (
                    MySqlCommand cmd =
                    new MySqlCommand("RegistrarPersonaBasico", conn)
                )
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "p_nombre",
                        nombre
                    );

                    cmd.Parameters.AddWithValue(
                        "p_apellido",
                        apellido
                    );
                    cmd.Parameters.AddWithValue(
                         "p_dni",
                         dni
                     );

                    // parámetro OUT
                    MySqlParameter salida =
                        new MySqlParameter(
                            "rta",
                            MySqlDbType.Int32
                        );

                    salida.Direction =
                        ParameterDirection.Output;

                    cmd.Parameters.Add(salida);

                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(salida.Value);
                }
            }
        }
    
        public void AgregarASocio(int personaId)
        {
            using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("agregarASocio", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id",
                        personaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarANoSocio(int personaId)
        {
            using(MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand("agregarANoSocio", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id", personaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

