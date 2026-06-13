using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ClubDeportivoApp.Repositories
{
    public class ClienteRepo
    {
        // Atributo de la clase. Necesario para la conexión a la DB
        private readonly ConexionMySql _conexionDatabase;

        // Se realiza inyección de dependencias para la conexión.
        public ClienteRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public int RegistrarClienteRepo(string nombre, string apellido, string dni, bool aptoFisico, bool esSocio)
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
                        "p_apto_fisico", aptoFisico);

                    cmd.Parameters.AddWithValue(
                       "p_es_socio", esSocio);

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

        public Cliente BuscarClientePorDniRepo(string dni)
        {
            Cliente cliente = null;

            using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using (
                    MySqlCommand cmd =
                    new MySqlCommand("BuscarClientePorDni", conn)
                )
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_dni", dni);

                    using (MySqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),
                                Dni = reader["dni"].ToString(),
                                //EsSocio = Convert.ToBoolean(reader["es_socio"]),
                                //Estado = reader["estado"] != DBNull.Value &&
                                    //Convert.ToBoolean(reader["estado"]),
                                AptoFisico = reader["apto_fisico"] != DBNull.Value &&
                                    Convert.ToBoolean(reader["apto_fisico"])
                            };
                        }

                    }
                }
            }
            return cliente;
        }

    }
}

