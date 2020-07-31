using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using ProyectoFinal_PA2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class ComprasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Compras compras = new Compras();

            compras.CompraId = 2;
            compras.SuplidorId = 0;
            compras.FechaDeCompra = DateTime.Now;
            compras.SubTotal = 400;
            compras.ITBIS = 0.18;
            compras.Descuento = 10;
            compras.Total = 350;

            paso = ComprasBLL.Guardar(compras);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;

            paso = ComprasBLL.Existe(1);

            if (paso)
                Assert.AreEqual(paso, true);
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Compras compras = new Compras();

            compras.CompraId = 2;
            compras.SuplidorId = 0;
            compras.FechaDeCompra = DateTime.Now;
            compras.SubTotal = 400;
            compras.ITBIS = 0.18;
            compras.Descuento = 10;
            compras.Total = 350;

            paso = ComprasBLL.Insertar(compras);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            //Este metodo se evalua en el guardar
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Compras compras = new Compras();

            compras.CompraId = 1;
            paso = ComprasBLL.Eliminar(compras.CompraId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = true;

            var compras = ComprasBLL.Buscar(1);

            if (compras != null)
            {
                paso = true;
                Assert.AreEqual(paso, true);
            }
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;
            var lista = ComprasBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                Assert.Fail();

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void DisminuirInventarioTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AumentarInventarioTest()
        {
            Assert.Fail();
        }
    }
}