﻿using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Constantes;

namespace CalidadT2.Repository
{

    public interface IBibliotecaRepository
    {
        public List<Biblioteca> Listar(Usuario usuario);
        public Biblioteca Buscar(int Id, Usuario usuario);
        public void Add(Biblioteca biblioteca);
        public void MarcarComoLeyendo(Biblioteca libro);
        public void MarcarComoTerminado(Biblioteca libro);
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

        public Biblioteca Buscar(int Id, Usuario usuario) {
            var model = context.Bibliotecas
                .Where(o => o.LibroId == Id && o.UsuarioId == usuario.Id)
                .FirstOrDefault();
            return model;
        }

        public void Add(Biblioteca biblioteca)
        {
            context.Bibliotecas.Add(biblioteca);
            context.SaveChanges();
        }

        public void MarcarComoLeyendo(Biblioteca libro)
        {
            libro.Estado = ESTADO.LEYENDO;
            context.SaveChanges();
        }

        public void MarcarComoTerminado(Biblioteca libro)
        {
            libro.Estado = ESTADO.TERMINADO;
            context.SaveChanges();
        }
    }
}
