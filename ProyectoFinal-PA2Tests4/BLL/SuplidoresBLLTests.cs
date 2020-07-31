using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using ProyectoFinal_PA2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Suplidores suplidores = new Suplidores();

            suplidores.SuplidorId = 1;
            suplidores.NombreSuplidor = "juan";
            suplidores.Apellidos = "fernandez";
            suplidores.NombreCompañia = "888-888-888";
            suplidores.Direccion = "SFM1";
            suplidores.Telefono = "888-888-888";
            suplidores.Celular = "888-888-888";
            suplidores.Email = "lol";
            suplidores.Ciudad = "SFM";
            suplidores.FechaIngreso = DateTime.Now;
            suplidores.UsuariosId = 0;

            paso = SuplidoresBLL.Guardar(suplidores);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;

            paso = SuplidoresBLL.Existe(1);

            if (paso)
                Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {

            bool paso;
            Suplidores suplidores = new Suplidores();

            suplidores.SuplidorId = 1;
            suplidores.NombreSuplidor = "juan";
            suplidores.Apellidos = "fernandez";
            suplidores.NombreCompañia = "888-888-888";
            suplidores.Direccion = "SFM1";
            suplidores.Telefono = "888-888-888";
            suplidores.Celular = "888-888-888";
            suplidores.Email = "lol";
            suplidores.Ciudad = "SFM";
            suplidores.FechaIngreso = DateTime.Now;
            suplidores.UsuariosId = 0;

            paso = SuplidoresBLL.Insertar(suplidores);
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
            Suplidores suplidores = new Suplidores();

            suplidores.SuplidorId = 1;
            paso = SuplidoresBLL.Eliminar(suplidores.SuplidorId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = true;

            var suplidores = SuplidoresBLL.Buscar(1);

            if (suplidores != null)
            {
                paso = true;
                Assert.AreEqual(paso, true);
            }
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;
            var lista = SuplidoresBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                Assert.Fail();

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExistenciaSuplidoresTest()
        {
            Assert.Fail();
        }
    }
}