﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void GuardarTest()
        {
            Personas p = new Personas();
            bool paso = false;
            p.personaId = 0;
            p.nombre = "Jose Perez";
            p.fecha = DateTime.Now;
            p.cedula = "40225550022";
            p.direccion = "Calle Duarte #44";
            p.telefono = "8099637885";
            p.balance = 0;
            paso = PersonasBLL.Guardar(p);
            Assert.AreEqual(paso, true);

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
            var lista = new List<Personas>();
            lista = PersonasBLL.GetList(p => true);
            Assert.AreEqual(lista, lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PersonasBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }
    }
}