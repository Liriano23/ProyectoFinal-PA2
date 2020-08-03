using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Productos productos = new Productos();

            productos.ProductoId = 1;
            productos.NombreProducto = "Goma";
            productos.MarcaProducto = "Michellin";
            productos.Inventario = 5;
            productos.FechaIngreso = DateTime.Now;
            productos.SuplidorId = 1;
            productos.CategoriaId = 1;
            productos.UsuariosId = 1;


            paso = ProductosBLL.Guardar(productos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;

            paso = ProductosBLL.Existe(1);

            if (paso)
                Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Productos productos = new Productos();

            productos.ProductoId = 0;
            productos.NombreProducto = "Gomas";
            productos.MarcaProducto = "Michelin";
            productos.Inventario = 5;
            productos.FechaIngreso = DateTime.Now;
            productos.SuplidorId = 1;
            productos.CategoriaId = 1;
            productos.UsuariosId = 1;


            paso = ProductosBLL.Guardar(productos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Productos productos = new Productos();

            productos.ProductoId = 1;
            paso = ProductosBLL.Eliminar(productos.ProductoId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = true;

            var ventas = ProductosBLL.Buscar(1);

            if (ventas != null)
            {
                paso = true;
                Assert.AreEqual(paso, true);
            }
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;
            var lista = ProductosBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                Assert.Fail();

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExistenciaProductosTest()
        {
            //Este metodo se encuntra en la clase de VerificacionExistenciaBLL. 
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