using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrestamo.BLL;
using RegistroPrestamo.DAL;
using RegistroPrestamo.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace RegistroPrestamo.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Personas personas = new Personas();
            Contexto contexto = new Contexto(); 
            bool guardado;
            personas.personaId = 0;
            personas.nombre = "Amauris Perez";
            personas.telefono = "8098968596";
            personas.cedula = "40225550011";
            personas.direccion = "Calle Duarte #558";
            personas.fecha = DateTime.Now;
            personas.balance = 0;

            guardado = contexto.Personas.Add(personas) != null;
            Assert.Equals(guardado, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Personas personas;
            personas = PersonasBLL.Buscar(2);
            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.Fail();
        }
    }
}