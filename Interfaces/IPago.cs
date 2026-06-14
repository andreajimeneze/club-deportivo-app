
namespace ClubDeportivoApp.Interfaces
{
    public interface IPago<T>
    {
        (bool Ok, string mensaje, T data) RegistrarPago(T entidad, decimal montoAPagar, int idConceptoPago, int idMedioPago);
        //List<Pago> listarPagosVencidos();
    }

}
