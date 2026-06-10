
namespace ClubDeportivoApp.Interfaces
{
    internal interface IRegistro
    {
        int RegistrarClienteRepo(string nombre, string apellido, string dni, bool aptoFisico);
        int AsignarTipoCliente(int clienteId, bool esSocio);
    }
}
