using ClubDeportivoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubDeportivoApp.Models;


namespace ClubDeportivoApp.Services
{
    internal class UsuarioService
    {
        private UsuarioRepository repository;

        public UsuarioService(UsuarioRepository repository)
        {
            this.repository = repository;
        }
        public Usuario LoginService(string username, string password)
        { 
            Usuario usuario = repository.LoginRepository(username, password);

            if (usuario == null)
            {
                return null;
            }

            if (usuario.RolId != 1)
            {
                return null;
            }

            return usuario; 
        }
    }
}
