using ClubDeportivoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubDeportivoApp.Models;


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
            Usuario usuario = repository.LoguearUsuario(username, password);

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
