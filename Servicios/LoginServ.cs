using ClubDeportivoApp.Repositorios;
using ClubDeportivoApp.Modelos;


namespace ClubDeportivoApp.Services
{
    internal class LoginServ
    {
        private LoginRepo repository;

        public LoginServ(LoginRepo repository)
        {
            this.repository = repository;
        }
        public Usuario Login(string username, string password)
        { 
            if(username == null || password == null)
            {
                return null;
            }
            Usuario usuario = repository.LoguearUsuario(username, password);

            if (usuario == null)
            {
                return null;
            }

            if (usuario.Rol.Nombre != "admin")
            {
                return null;
            }

            return usuario; 
        }
    }
}
