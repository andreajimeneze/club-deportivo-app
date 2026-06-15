using ClubDeportivoApp.DTOS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public List<CuotaDTO> ObtenerCuotasRepo(string dni)
        {
            List<CuotaDTO> cuotas = new List<CuotaDTO>();

            using (
                MySqlConnection conn =
                _conexionDatabase.GetMySqlConnection()
            )
            {
                using (
                    MySqlCommand cmd =
                    new MySqlCommand("ObtenerCuotasPorDni", conn)
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
                        while (reader.Read())
                        {
                            CuotaDTO cuota = new CuotaDTO
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

                            cuotas.Add(cuota);
                        }
                    }

                }
            }
            return cuotas;
        }

    }
}


