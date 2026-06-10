using ClubDeportivoApp.DTOS;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ClubDeportivoApp.Repositorios
{
    public class CuotaRepo
    {
        private readonly ConexionMySql _conexionDatabase;

        public CuotaRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public CuotaPendienteDTO ObtenerCuotaPendienteRepo(string dni)
        {
            CuotaPendienteDTO cuota = null;

            using (
                MySqlConnection conn =
                _conexionDatabase.GetMySqlConnection()
            )
            {
                using (
                    MySqlCommand cmd =
                    new MySqlCommand("ObtenerCuotaPendiente", conn)
                )
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "in_dni",
                        dni
                    );
                    using (MySqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cuota = new CuotaPendienteDTO
                            {
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),
                                Dni = reader["dni"].ToString(),
                                IdSocio = Convert.ToInt32(reader["id"]),
                                EstadoSocio = Convert.ToBoolean(reader["estado_socio"]),
                                MontoCuota = Convert.ToDecimal(reader["monto_cuota"]),
                                FechaVencimiento = Convert.ToDateTime(reader["fecha_vencimiento"]),
                                EstadoCuota = reader["estado_cuota"].ToString()
                            };  
                        }
                    }

                }
            }
            return cuota;
        }

    }
}


