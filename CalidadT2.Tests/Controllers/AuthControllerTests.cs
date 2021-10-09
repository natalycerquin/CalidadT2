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
    class AuthControllerTests
    {
        [Test]
        public void TestIndex()
        {
            var mock = new Mock<IUsuarioRepository>();
            mock.Setup(o => o.IniciarSesion("admin", "1234")).Returns((Usuario)null);
            var controller = new AuthController(mock.Object);

            var result = controller.Login("admin", "1234") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsTrue(controller.ModelState.IsValid);
        }
    }
}
