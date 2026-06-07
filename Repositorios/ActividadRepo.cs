using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
 
                string query = "SELECT id, nombre FROM actividades";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<Actividad> actividades = new List<Actividad>();
                        while (dr.Read())
                        {
                            Actividad actividad = new Actividad
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["nombre"].ToString()
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
