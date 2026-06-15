using ClubDeportivoApp.DTOS;
using MySql.Data.MySqlClient;
using System;
using System.Data;

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

           
            using(MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand("BuscarReservaPorId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_id_reserva", idReserva);

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            reserva = new ReservaDTO
                            {
                                IdReserva = Convert.ToInt32(reader["id_reserva"]),
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                NombreCliente = reader["nombre"].ToString(),
                                ApellidoCliente = reader["apellido"].ToString(),
                                Dni = reader["dni"].ToString(),
                                Actividad = reader["actividad"].ToString(),
                                Precio = Convert.ToDecimal(reader["precio"]),
                                FechaHora = Convert.ToDateTime(reader["fecha_hora"]),
                                EstadoReserva = reader["estado"].ToString()                              

                            };
                        }
                                            
                    }
                }
            }
            return reserva;
        }

        // Busca cualquier reserva por id sin importar el estado
        // Usalo internamente; en la BD podés crear un SP similar a BuscarReservaPorId
        // pero sin el filtro de estado, o bien reutilizás BuscarReservaPorDniYActividad
        public ReservaDTO BuscarReservaAutorizadaPorId(int idReserva)
        {
            ReservaDTO reserva = null;

            using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                // Consulta directa: no depende del estado
                string query = @"
            SELECT 
                r.id        AS id_Reserva,
                r.estado,
                r.cliente_id AS id_cliente,
                p.nombre,
                p.apellido,
                p.dni,
                a.nombre    AS actividad,
                a.precio,
                pr.fecha_hora
            FROM reservas r
            INNER JOIN programaciones pr ON r.programacion_id = pr.id
            INNER JOIN actividades a     ON pr.actividad_id   = a.id
            INNER JOIN clientes cl       ON r.cliente_id      = cl.id
            INNER JOIN personas p        ON cl.persona_id     = p.id
            WHERE r.id = @idReserva";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reserva = new ReservaDTO
                            {
                                IdReserva = Convert.ToInt32(reader["id_Reserva"]),
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                NombreCliente = reader["nombre"].ToString(),
                                ApellidoCliente = reader["apellido"].ToString(),
                                Dni = reader["dni"].ToString(),
                                Actividad = reader["actividad"].ToString(),
                                Precio = Convert.ToDecimal(reader["precio"]),
                                FechaHora = Convert.ToDateTime(reader["fecha_hora"]),
                                EstadoReserva = reader["estado"].ToString()
                            };
                        }
                    }
                }
            }
            return reserva;
        }
        public ReservaDTO BuscarReservaPorDniYActividadRepo(string dni, int idActividad)
        {
            ReservaDTO reserva = null;


            using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("BuscarReservaPorDniYActividad", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_dni", dni);
                    cmd.Parameters.AddWithValue("p_id_actividad", idActividad);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reserva = new ReservaDTO
                            {
                                IdReserva = Convert.ToInt32(reader["id_reserva"]),
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                NombreCliente = reader["nombre"].ToString(),
                                ApellidoCliente = reader["apellido"].ToString(),
                                Dni = reader["dni"].ToString(),
                                IdActividad = Convert.ToInt32(reader["id_actividad"]),
                                Actividad = reader["actividad"].ToString(),
                                Precio = Convert.ToDecimal(reader["precio"]),
                                FechaHora = Convert.ToDateTime(reader["fecha_hora"]),
                                EstadoReserva = reader["estado"].ToString()

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
                using(MySqlCommand cmd = new MySqlCommand("GenerarReserva", conn))
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
