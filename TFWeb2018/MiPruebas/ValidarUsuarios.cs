using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TFWeb2018.Models;
using TFWeb2018.Models.DAO;

namespace MiPruebas
{
    [TestClass]
    public class ValidarUsuarios
    {

        [TestMethod]
        public void TestMethod1()
        {
            Persona persona = new Persona()
            {
                Nombre = "Diego",
                Edad = 21,
                Correo = "diego_13_1999@hotmail.com",
                Username = "ProDg",
                Password = "*****"
            };
            UsuariosCreae uc = new UsuariosCreae();
            bool respuesta = uc.TieneMasDeDieciOcho(persona.Edad);
            bool respuestaEsperada = true;

            Assert.AreEqual(respuesta, respuestaEsperada);

        }
        /*
        [TestMethod]
        public void TestMethod2()
        {
            Persona persona = new Persona();
            Venta venta = new Venta();
            var mockPersona = new Mock<DAOUsuario>();
            var mockCompra = new Mock<DAOVenta>();
            mockPersona.Setup(sp => sp.addUsuario(persona.Id_Persona,"ProDg", "todo",persona.Nombre,persona.Edad, persona.Correo,
            persona.Username,"****")).Returns(true);
            mockCompra.Setup(sp => sp.AgregarVenta(venta.Id_Venta, persona.Id_Persona, DateTime.Now.Date)).Returns(true);
                    
        }*/

     
    }
}
