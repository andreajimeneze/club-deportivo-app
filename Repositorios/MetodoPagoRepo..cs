using ClubDeportivoApp.Interfaces;
using ClubDeportivoApp.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace ClubDeportivoApp.Repositorios
{
    internal class MetodoPagoRepo : IListado<MetodoPago>
    {
        private ConexionMySql conexionMysql;
        
        public MetodoPagoRepo(ConexionMySql conexionMysql)
        {
            
            this.conexionMysql = conexionMysql;
 
        }
        public List<MetodoPago> ObtenerLista()
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

    }
}
