using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repository
{

    public interface IUsuarioRepository
    {
        public Usuario Buscar(string username, string password);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private AppBibliotecaContext context;

        public UsuarioRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }

        public Usuario Buscar(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
