using ClubDeportivoApp.DTOS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Repositorios
{
    public class ReservaRepo
    {
        private readonly ConexionMySql _conexionDatabase;

        public ReservaRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public ReservaDTO BuscarReservaPorId(int idReserva)
        {
            ReservaDTO reserva = null;

            string query = "SELECT r.id AS idReserva, r.pagada, cl.id AS idCliente, p.nombre, p.apellido, p.dni, a.nombre AS actividad, a.precio, pr.fecha_hora" +
                " FROM reservas r INNER JOIN programaciones pr" +
                " ON r.programacion_id = pr.id" +
                " INNER JOIN actividades a ON pr.actividad_id = a.id" +
                " INNER JOIN clientes cl ON r.cliente_id = cl.id" +
                " INNER JOIN personas p ON cl.persona_id = p.id" +
                " WHERE r.id = @idReserva";
            using(MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            reserva = new ReservaDTO
                            {
                                IdReserva = Convert.ToInt32(reader["idReserva"]),
                                IdCliente = Convert.ToInt32(reader["idCliente"]),
                                NombreCliente = reader["nombre"].ToString(),
                                ApellidoCliente = reader["apellido"].ToString(),
                                Dni = reader["dni"].ToString(),
                                Actividad = reader["actividad"].ToString(),
                                Precio = Convert.ToDecimal(reader["precio"]),
                                FechaHora = Convert.ToDateTime(reader["fecha_hora"]),
                                Pagada = Convert.ToBoolean(reader["pagada"])

                            };
                        }
                                            
                    }
                }
            }
            return reserva;
        }


        public int GenerarReservaRepo(int idActividad, int clienteId, DateTime fecha_hora)
        {
            using(MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand("generarReserva", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_actividad", idActividad);
                    cmd.Parameters.AddWithValue("p_cliente_id", clienteId);
                    cmd.Parameters.AddWithValue("p_fecha_hora", fecha_hora);

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
    }
}
