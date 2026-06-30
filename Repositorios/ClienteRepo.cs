using ClubDeportivoApp.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace ClubDeportivoApp.Repositorios
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
                using (MySqlCommand cmd = new MySqlCommand("BuscarClientePorDni", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_dni", dni);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idCliente = Convert.ToInt32(reader["id_cliente"]);
                            string nombre = reader["nombre"].ToString();
                            string apellido = reader["apellido"].ToString();
                            string dniVal = reader["dni"].ToString();
                            bool aptoFisico = reader["apto_fisico"] != DBNull.Value &&
                                              Convert.ToBoolean(reader["apto_fisico"]);
                            string tipo = reader["tipo_cliente"].ToString();

                            if (tipo == "Socio")
                            {
                                int idSocio = Convert.ToInt32(reader["id_socio"]);
                                bool estado = reader["estado_socio"] != DBNull.Value &&
                                              Convert.ToBoolean(reader["estado_socio"]);

                                cliente = new Socio(idCliente, nombre, apellido, dniVal, aptoFisico, estado)
                                {
                                    IdSocio = idSocio
                                };
                            }
                            else if (tipo == "NoSocio")
                            {
                                int idNoSocio = Convert.ToInt32(reader["id_no_socio"]);
                                bool accesoDiario = reader["acceso_diario"] != DBNull.Value &&
                                                    Convert.ToBoolean(reader["acceso_diario"]);

                                cliente = new NoSocio(idCliente, nombre, apellido, dniVal, aptoFisico)
                                {
                                    IdNoSocio = idNoSocio,
                                    AccesoDiario = accesoDiario
                                };
                            }
                            else
                            {
                                cliente = new Cliente(idCliente, nombre, apellido, dniVal, aptoFisico);
                            }
                        }
                    }
                }
            }
            return cliente;
        }

        public bool ActualizarAptoFisico(Cliente cliente)
        {
            string query = "UPDATE clientes SET apto_fisico = true WHERE id = @id";
            
            using(MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", cliente.IdCliente);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }

        public List<Cliente> BuscarClientesRepo()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string query = "SELECT cl.id, p.nombre, p.apellido, p.dni, cl.apto_fisico," +
                    " s.id AS socio_id" +
                    " FROM personas p" +
                    " INNER JOIN clientes cl ON p.id = cl.persona_id" +
                    " LEFT JOIN socios s ON cl.id = s.cliente_id" +
                    " LEFT JOIN no_socios ns ON cl.id = ns.cliente_id" +
                    " ORDER BY cl.id ASC"; ;

            using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bool esSocio = reader["socio_id"] != DBNull.Value;

                    Cliente cliente = esSocio
                        ? new Socio() :
                        new Cliente();

                    cliente.IdCliente = Convert.ToInt32(reader["id"]);
                    cliente.Nombre = reader["nombre"].ToString();
                    cliente.Apellido = reader["apellido"].ToString();
                    cliente.Dni = reader["dni"].ToString();
                    cliente.AptoFisico = Convert.ToBoolean(reader["apto_fisico"]);
                    

                    listaClientes.Add(cliente);
                }
            }

            return listaClientes;
        }

        public int AsignarANoSocio(Cliente cliente)
        {
            string query =
                "INSERT INTO no_socios(cliente_id, acceso_diario) VALUES(@id, true)";

            using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", cliente.IdCliente);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

