using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using ClubDeportivoApp.DTOS;

namespace ClubDeportivoApp.Repositorios
{
    public class VencimientoRepo
    {
        private readonly ConexionMySql _conexion;

        public VencimientoRepo(ConexionMySql conexion)
        {
            _conexion = conexion;
        }

        public DataTable ObtenerVencimientosPorFecha(DateTime fecha)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = _conexion.GetMySqlConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand("ListarVencimientos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_fecha_vencimiento", fecha);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
