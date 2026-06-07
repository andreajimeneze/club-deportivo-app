using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Repositorios
{
    public class SocioRepo
    {
        private readonly ConexionMySql _conexionDatabase;

        public SocioRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public bool BuscarSocioPorDNI(string dni)
        {
            string query = "SELECT 1 FROM socios s JOIN clientes cl ON cl.id = s.cliente_id " +
                "JOIN personas p ON p.id = cl.persona_id WHERE p.dni = @dni";

            using(MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using (
                    MySqlCommand cmd =
                    new MySqlCommand(query, conn)
                )
                {
                    cmd.Parameters.AddWithValue("@dni", dni);

                    using (MySqlDataReader reader =
                           cmd.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
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
                                EstadoSocio = Convert.ToBoolean(reader["estado"]),
                                MontoCuota = Convert.ToDecimal(reader["monto_cuota"]),
                                FechaVencimiento = Convert.ToDateTime(reader["fecha_vencimiento"])
                            };  
                        }
                    }

                }
            }
            return cuota;
        }

    }
}


