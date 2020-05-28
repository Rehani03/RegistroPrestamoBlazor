using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrestamo.BLL;
using RegistroPrestamo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamo.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Prestamo prestamo = new Prestamo();
            prestamo.prestamoId = 0;
            prestamo.fecha = DateTime.Now;
            prestamo.personaId = 1;
            prestamo.concepto = "Comida";
            prestamo.monto = 100;
            prestamo.balance = 100;
            bool paso = PrestamosBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PrestamosBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamo prestamo;
            prestamo = PrestamosBLL.Buscar(2);
            Assert.AreEqual(prestamo, prestamo);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Prestamo>();
            lista = PrestamosBLL.GetList(p => true);
            Assert.AreEqual(lista, lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = PrestamosBLL.Existe(2);
            Assert.AreEqual(paso, true);
        }
    }
}