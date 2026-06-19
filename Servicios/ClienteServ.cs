
using ClubDeportivoApp.Modelos;
using ClubDeportivoApp.Repositorios;


namespace ClubDeportivoApp.Servicios
{
    public class ClienteServ
    {
        private ClienteRepo _repo;

        public ClienteServ(ClienteRepo repo)
        {
            _repo = repo;
        }

        public (bool Ok, string mensaje, Cliente cliente) RealizarRegistro(Cliente cliente, bool esSocio)
        {
            if (cliente == null)
            {
                return (false, "No se puede realizar registro sin información", null);
            }
            
           
            int idRegistrado = _repo.RegistrarClienteRepo(cliente.Nombre, cliente.Apellido, cliente.Dni, cliente.AptoFisico, esSocio);

            
            if(idRegistrado <= 0)
            {
                return (false, "Error al realizar el registro", null);
                
            }
            cliente.IdCliente = idRegistrado;

            // Si es socio, asignar también IdSocio
            if (esSocio && cliente is Socio socio)
            {
                socio.IdSocio = idRegistrado;  
            }

            return (true, "Cliente registrado con éxito", cliente);


        }


        public Cliente BuscarClientePorDni(string dni)
        {
            Cliente clienteBuscado = _repo.BuscarClientePorDniRepo(dni);
            if (clienteBuscado == null)
            {
                return null;
            }

            return clienteBuscado;
        }

        public bool ActualizarAptoFisico(Cliente cliente)
        {
            return _repo.ActualizarAptoFisico(cliente);
        }

        public int AsignarANoSocio(Cliente cliente)
        {
            return _repo.AsignarANoSocio(cliente);
        }
    }
}
