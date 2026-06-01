using ClubDeportivoApp.Interfaces;
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
    internal class InscripcionSocioRepo : IInscripcion
    {
        private readonly ConexionMySql _conexionDatabase;

        // Se realiza inyección de dependencias para la conexión.
        public InscripcionSocioRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public int FormalizarInscripcion(int socioId, decimal monto, int conceptoId, int metodoId)
        {
            try
            {
                using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand("FormalizarInscripcion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_socio_id", socioId);
                        cmd.Parameters.AddWithValue("p_monto", monto);
                        cmd.Parameters.AddWithValue("p_concepto_id", conceptoId);
                        cmd.Parameters.AddWithValue("p_metodo_id", metodoId);

                        MySqlParameter rtaParameter = new MySqlParameter("rta", MySqlDbType.Int32);

                        rtaParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(rtaParameter);

                        cmd.ExecuteNonQuery();
                        return Convert.ToInt32(rtaParameter.Value);
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception("Error repo inscripción: " + ex.Message, ex);
            }
        }
    }
}
