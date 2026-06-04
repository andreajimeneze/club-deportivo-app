using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace ClubDeportivoApp.Repositorios
{
    internal class PagosRepo
    {
        private readonly ConexionMySql _conexionDatabase;

        // Se realiza inyección de dependencias para la conexión.
        public PagosRepo(ConexionMySql conexionDatabase)
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
            } catch(Exception ex)
            {
                throw new Exception("Error repo inscripción: " + ex.Message, ex);
            }
        }

        public int RegistrarPago(int ? socioId, int ? noSocioId, decimal montoAPagar, int conceptoPago, int medioPago )
        {
            try
            {
                using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand("RegistrarPago", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_socio_id", socioId.HasValue ? (object)socioId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("p_no_socio_id", noSocioId.HasValue ? (object)noSocioId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("p_monto", montoAPagar);
                        cmd.Parameters.AddWithValue("p_concepto_id", conceptoPago);
                        cmd.Parameters.AddWithValue("p_metodo_id", medioPago);

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
