using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repository
{

    public interface IBibliotecaRepository
    {
        public void Listar();
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

        public void Listar()
        {
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
