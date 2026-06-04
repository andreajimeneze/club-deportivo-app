
namespace ClubDeportivoApp.Interfaces
{
    internal interface IRegistro
    {
        int RegistrarCliente(string nombre, string apellido, string dni, bool aptoFisico);
        int AsignarTipoCliente(int clienteId, bool esSocio);
    }
}
