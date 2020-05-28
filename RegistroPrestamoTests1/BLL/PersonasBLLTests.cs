using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrestamo.BLL;
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
        public void InsertarTest()
        {
            Personas personas = new Personas();
            bool paso;
            personas.personaId = 0;
            personas.nombre = "Juan Camilo";
            personas.telefono = "8297899632";
            personas.cedula = "40225550011";
            personas.direccion = "Calle Duarte#11";
            personas.fecha = DateTime.Now;
            personas.balance = 0;
            paso = PersonasBLL.Insertar(personas);
            Assert.AreEqual(paso, true);
        }
    }
}