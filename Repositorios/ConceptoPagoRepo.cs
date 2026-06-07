using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace ClubDeportivoApp.Repositorios
{
    internal class ConceptoPagoRepo : IListado<ConceptoPago>
    {
        private ConexionMySql conexionMysql;
        
        public ConceptoPagoRepo(ConexionMySql conexionMysql)
        {
            
            this.conexionMysql = conexionMysql;
 
        }
        
        public List<ConceptoPago> ObtenerLista()
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

       

    }
}
