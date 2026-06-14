using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace ClubDeportivoApp.Repositorios
{
    internal class ActividadRepo : IListado<Actividad>
    {
        private ConexionMySql conexionMysql;
        
        public ActividadRepo(ConexionMySql conexionMysql)
        {
            
            this.conexionMysql = conexionMysql;
 
        }

        public List<Actividad> ObtenerLista()
        {

            using (MySqlConnection conn = conexionMysql.GetMySqlConnection())
            {
 
                string query = "SELECT id, nombre, precio FROM actividades";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Actividad> actividades = new List<Actividad>();
                        while (reader.Read())
                        {
                            Actividad actividad = new Actividad
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Precio = Convert.ToDecimal(reader["precio"])
                            };

                            actividades.Add(actividad);
                        }
                        return actividades;
                    }
                }
            }
        }

    }
}
