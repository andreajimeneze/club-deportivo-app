using ClubDeportivoApp.DTOS;
using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivoApp.Repositorios
{
    public class ProgramacionRepo : IListado<ProgramacionDTO>
    {
        private readonly ConexionMySql _conexionDatabase;

        public ProgramacionRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public List<ProgramacionDTO> ObtenerLista()
        {
            string query = "SELECT a.id AS id_act, a.nombre, a.precio, p.fecha_hora, p.id AS id_prog, p.cupos_disponibles" +
                "FROM programaciones p INNER JOIN actividades a ON a.id = p.actividad_id";

            using(MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ProgramacionDTO> listaProgramacion = new List<ProgramacionDTO>();
                        
                          while (reader.Read())
                            {
                            ProgramacionDTO programacion = new ProgramacionDTO
                            {
                                IdProgramacion = Convert.ToInt32(reader["id_prog"]),
                                IdActividad = Convert.ToInt32(reader["id_act"]),
                                NombreActividad = reader["nombre"].ToString(),
                                PrecioActividad = Convert.ToDecimal(reader["precio"]),
                                FechaHora = Convert.ToDateTime(reader["fecha_hora"]),
                                CuposDisponibles = Convert.ToInt32(reader["cupos_disponibles"])
                            };

                            listaProgramacion.Add(programacion);
                            }
                        return listaProgramacion;                        
                    }
                }
            }
        }
    }
}
