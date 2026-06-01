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
    internal class ListadosMaestrosRepo
    {
        private ConexionMySql conexionMysql;
        
        public ListadosMaestrosRepo(ConexionMySql conexionMysql)
        {
            
            this.conexionMysql = conexionMysql;
 
        }
        public List<MetodoPago> ObtenerListadoMetodos()
        {
            
            using (MySqlConnection conn = conexionMysql.GetMySqlConnection())
            {
                string query = "SELECT id, nombre FROM metodos_pago";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using(MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<MetodoPago> listaMetodosPago = new List<MetodoPago>();
                        while(dr.Read())
                        {
                            MetodoPago metodo = new MetodoPago
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["nombre"].ToString()
                            };

                            listaMetodosPago.Add(metodo);
                        }
                        return listaMetodosPago;
                    }
                    
                }
            }
        }

        public List<ConceptoPago> ObtenerListadoConceptos()
        {
            using (MySqlConnection conn = conexionMysql.GetMySqlConnection())
            {
                string query = "SELECT id, nombre FROM conceptos_pago";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<ConceptoPago> listaConceptoPago = new List<ConceptoPago>();
                        while (dr.Read())
                        {
                            ConceptoPago concepto = new ConceptoPago
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["nombre"].ToString()
                            };

                            listaConceptoPago.Add(concepto);
                        }
                        return listaConceptoPago;
                    }
                }
            }
        }

        public List<Actividad> ObtenerListadoActividades()
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
