using ClubDeportivoApp.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace ClubDeportivoApp.Repositorios
{
    public class ProgramacionRepo   
    {
        private readonly ConexionMySql _conexionDatabase;

        public ProgramacionRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public List<Programacion> BuscarProgramacionPorActividad(int idActividad)
        {
            string query = "SELECT a.id AS id_act, p.fecha_hora, p.id AS id_prog, p.cupos_disponibles" +
                " FROM programaciones p INNER JOIN actividades a ON a.id = p.actividad_id " +
                " WHERE a.id = @idActividad" +
                " ORDER BY p.fecha_hora ASC";

            using(MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idActividad", idActividad);

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Programacion> listaProgramacion = new List<Programacion>();
                        
                          while (reader.Read())
                            {
                            Programacion programacion = new Programacion
                            {
                                Id = Convert.ToInt32(reader["id_prog"]),
                                FechaHora = Convert.ToDateTime(reader["fecha_hora"]),
                                CuposDisponibles = Convert.ToInt32(reader["cupos_disponibles"]),
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
