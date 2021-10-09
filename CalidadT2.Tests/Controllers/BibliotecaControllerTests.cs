using CalidadT2.Constantes;
using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2.Tests.Controllers
{
    class BibliotecaControllerTests
    {
        private Mock<IAuthRepository> authRepository;
        private Mock<IBibliotecaRepository> bibliotecaRepository;

        [SetUp]
        public void SetUp()
        {
            authRepository = new Mock<IAuthRepository>();
            bibliotecaRepository = new Mock<IBibliotecaRepository>();
        }

        [Test]
        public void TestIndexIsOkCase01()
        {
            var usuario = new Models.Usuario() { Id = 1, Nombres = "admin", Username = "admin" };
            authRepository.Setup(o => o.GetUserLogged(null)).Returns(usuario);
            bibliotecaRepository.Setup(o => o.Listar(usuario)).Returns(new List<Biblioteca>());

            var controller = new BibliotecaController(bibliotecaRepository.Object, authRepository.Object);
            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<Biblioteca>>(view.Model);
        }

        [Test]
        public void TestAdd()
        {
            var usuario = new Models.Usuario() { Id = 1, Nombres = "admin", Username = "admin" };
            authRepository.Setup(o => o.GetUserLogged(null)).Returns(usuario);
            bibliotecaRepository.Setup(o => o.Listar(usuario)).Returns(new List<Biblioteca>());

            var controller = new BibliotecaController(bibliotecaRepository.Object, authRepository.Object);
            var result = controller.Add(1) as ViewResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void TestMarcarComoLeyendo()
        {
            var usuario = new Usuario() { Id = 1, Nombres = "admin", Username = "admin" };
            var biblioteca = new Biblioteca() { Id = 1, Estado = ESTADO.LEYENDO, LibroId = 1, UsuarioId = 1 };
            authRepository.Setup(o => o.GetUserLogged(null)).Returns(usuario);
            bibliotecaRepository.Setup(o => o.Buscar(1, usuario)).Returns(biblioteca);

            var controller = new BibliotecaController(bibliotecaRepository.Object, authRepository.Object);
            var result = controller.MarcarComoLeyendo(1) as ViewResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void TestMarcarComoTerminado()
        {
            var usuario = new Usuario() { Id = 1, Nombres = "admin", Username = "admin" };
            var biblioteca = new Biblioteca() { Id = 1, Estado = ESTADO.TERMINADO, LibroId = 1, UsuarioId = 1 };
            authRepository.Setup(o => o.GetUserLogged(null)).Returns(usuario);
            bibliotecaRepository.Setup(o => o.Buscar(1, usuario)).Returns(biblioteca);

            var controller = new BibliotecaController(bibliotecaRepository.Object, authRepository.Object);
            var result = controller.MarcarComoTerminado(1) as ViewResult;

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }
}
