using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using ProyectoFinal_PA2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class CategoriasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 1;
            categorias.NombreCategoria = "Goma";
            categorias.FechaIngreso = DateTime.Now;
            categorias.UsuariosId = 0;

            paso = CategoriasBLL.Guardar(categorias);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;

            paso = UsuariosBLL.Existe(1);

            if (paso)
                Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 0;
            categorias.NombreCategoria = "Guantes";
            categorias.FechaIngreso = DateTime.Now;
            categorias.UsuariosId = 0;

            paso = CategoriasBLL.Insertar(categorias);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 0;
            categorias.NombreCategoria = "Guantess";
            categorias.FechaIngreso = DateTime.Now;
            categorias.UsuariosId = 0;

            paso = CategoriasBLL.Modificar(categorias);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 1;
            paso = CategoriasBLL.Eliminar(categorias.CategoriaId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = true;

            var categorias = CategoriasBLL.Buscar(1);

            if (categorias != null)
            {
                paso = true;
                Assert.AreEqual(paso, true);
            }
        }


        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;
            var lista = CategoriasBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                Assert.Fail();

            Assert.AreEqual(paso, true);
        }
    }
}