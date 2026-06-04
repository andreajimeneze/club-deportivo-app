using ClubDeportivoApp.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ClubDeportivoApp.Repositories
{
    internal class RegistroRepo : IRegistro
    {
        // Atributo de la clase. Necesario para la conexión a la DB
        private readonly ConexionMySql _conexionDatabase;

        // Se realiza inyección de dependencias para la conexión.
        public RegistroRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public int RegistrarCliente(string nombre, string apellido, string dni, bool aptoFisico)
        {
            using (
                MySqlConnection conn =
                _conexionDatabase.GetMySqlConnection()
            )
            {
                using (
                    MySqlCommand cmd =
                    new MySqlCommand("RegistrarCliente", conn)
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

                    cmd.Parameters.AddWithValue(
                        "p_aptoFisico", aptoFisico);

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
    
        public int AsignarTipoCliente(int clienteId, bool esSocio)
        {
            using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("asignarTipoCliente", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_cliente_id",
                        clienteId);

                    cmd.Parameters.AddWithValue("p_es_socio",
                        esSocio);

                    MySqlParameter rtaParameter = new MySqlParameter("rta", MySqlDbType.Int32);

                    rtaParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(rtaParameter);

                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(rtaParameter.Value);
                }
            }
        }
    }
}

