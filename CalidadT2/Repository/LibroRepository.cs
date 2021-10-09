﻿using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repository
{
    public interface ILibroRepository
    {
        public Libro Buscar(int Id);
    }

    public class LibroRepository : ILibroRepository
    {
        private AppBibliotecaContext context;

        public LibroRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }

        public Libro Buscar(int Id)
        {
            var model = context.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == Id)
                .FirstOrDefault();
            return model;
        }
    }
}
