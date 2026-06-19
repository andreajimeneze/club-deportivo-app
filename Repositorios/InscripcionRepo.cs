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

        public int FormalizarInscripcion(int clienteId, decimal montoCuota)
        {
            try
            {
                using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand("FormalizarInscripcion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_cliente_id", clienteId);
                        cmd.Parameters.AddWithValue("p_monto_cuota", montoCuota);

                        MySqlParameter rtaParameter = new MySqlParameter("rta", MySqlDbType.Int32);

                        rtaParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(rtaParameter);

                        cmd.ExecuteNonQuery();

                        object value = cmd.Parameters["rta"].Value;

                        if (value == null || value == DBNull.Value)
                            return -99;

                        return Convert.ToInt32(value);
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
