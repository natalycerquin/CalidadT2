using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repository
{

    public interface IBibliotecaRepository
    {
        public List<Biblioteca> Listar(Usuario usuario);
        public void Buscar(int Id);
        public void Add();
        public void MarcarComoLeyendo();
        public void MarcarComoTerminado();
    }

    public class BibliotecaRepository : IBibliotecaRepository
    {
        private AppBibliotecaContext context;

        public BibliotecaRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }

        public List<Biblioteca> Listar(Usuario usuario)
        {
            var model = context.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == usuario.Id)
                .ToList();

            return model;
        }

        public void Buscar(int Id) {
        }

        public void Add()
        {
        }

        public void MarcarComoLeyendo()
        {
        }

        public void MarcarComoTerminado()
        {
        }
    }
}
