using ClubDeportivoApp.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace ClubDeportivoApp.Repositorios
{
    public class PagosRepo : IContrato
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
        public int RegistrarPagoCuota(int idSocio, decimal montoAPagar, int conceptoPago, int medioPago)
        {
            
            try
            {
                using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
                {
                  
                    using (MySqlCommand cmd = new MySqlCommand("RegistrarPagoCuota", conn))
                    {
                      
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_socio_id", idSocio);                     
                        cmd.Parameters.AddWithValue("p_monto", montoAPagar);
                        cmd.Parameters.AddWithValue("p_concepto_id", conceptoPago);
                        cmd.Parameters.AddWithValue("p_metodo_id", medioPago);

                        MySqlParameter rtaParameter = new MySqlParameter("rta", MySqlDbType.Int32);

                        rtaParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(rtaParameter);
                       
                        cmd.ExecuteNonQuery();
                        if (rtaParameter.Value == null || rtaParameter.Value == DBNull.Value)
                        {
                            return -1;
                        }
                        return Convert.ToInt32(rtaParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error repo inscripción: " + ex.Message, ex);
            }
        }


        public int RegistrarPagoActividad(int idReserva, decimal montoAPagar, int conceptoPago, int medioPago)
        {

            try
            {
                using (MySqlConnection conn = _conexionDatabase.GetMySqlConnection())
                {

                    using (MySqlCommand cmd = new MySqlCommand("RegistrarPagoActividad", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_monto", montoAPagar);
                        cmd.Parameters.AddWithValue("p_reserva_id", idReserva);
                        cmd.Parameters.AddWithValue("p_concepto_id", conceptoPago);
                        cmd.Parameters.AddWithValue("p_metodo_id", medioPago);

                        MySqlParameter rtaParameter = new MySqlParameter("rta", MySqlDbType.Int32);

                        rtaParameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(rtaParameter);

                        cmd.ExecuteNonQuery();
                        if (rtaParameter.Value == null || rtaParameter.Value == DBNull.Value)
                        {
                            return -1;
                        }
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
