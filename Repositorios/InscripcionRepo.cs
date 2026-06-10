using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ClubDeportivoApp.Repositorios
{
    public class InscripcionRepo
    {
        private readonly ConexionMySql _conexionDatabase;

        public InscripcionRepo(ConexionMySql conexionDatabase)
        {
            _conexionDatabase = conexionDatabase;
        }

        public int FormalizarContrato(int socioId, decimal montoCuota)
        {
            try
            {
                using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand("FormalizarInscripcion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_socio_id", socioId);
                        cmd.Parameters.AddWithValue("p_monto_cuota", montoCuota);

                        MySqlParameter rtaParameter = new MySqlParameter("rta", MySqlDbType.Int32);

                        rtaParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(rtaParameter);

                        cmd.ExecuteNonQuery();
                        return Convert.ToInt32(rtaParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error repo inscripción: " + ex.Message, ex);
            }
        }
    }
}
