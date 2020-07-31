using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using ProyectoFinal_PA2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class EmpleadosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Empleados empleados = new Empleados();

            empleados.EmpleadoId = 1;
            empleados.Nombres = "juan";
            empleados.Apellidos = "Fernandez";
            empleados.Cedula = "000-111-7777";
            empleados.Direccion = "sfm";
            empleados.Telefono = "888-888-888";
            empleados.Celular = "888-888-888";
            empleados.Email = "jua@juan.com";
            empleados.Cargo = "Gerente";
            empleados.Sueldo = 50000;
            empleados.FechaNacimiento = DateTime.Now;
            empleados.FechaIngreso = DateTime.Now;
            empleados.UsuariosId = 0;

            paso = EmpleadosBLL.Guardar(empleados);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;

            paso = EmpleadosBLL.Existe(1);

            if (paso)
                Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Empleados empleados = new Empleados();

            empleados.EmpleadoId = 1;
            empleados.Nombres = "juan";
            empleados.Apellidos = "Fernandez";
            empleados.Cedula = "000-111-7777";
            empleados.Direccion = "sfm";
            empleados.Telefono = "888-888-888";
            empleados.Celular = "888-888-888";
            empleados.Email = "jua@juan.com";
            empleados.Cargo = "Gerente";
            empleados.Sueldo = 50000;
            empleados.FechaNacimiento = DateTime.Now;
            empleados.FechaIngreso = DateTime.Now;
            empleados.UsuariosId = 0;

            paso = EmpleadosBLL.Insertar(empleados);
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
            Empleados empleados = new Empleados();

            empleados.EmpleadoId = 1;
            paso = ClientesBLL.Eliminar(empleados.EmpleadoId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = true;

            var empleados = EmpleadosBLL.Buscar(1);

            if (empleados != null)
            {
                paso = true;
                Assert.AreEqual(paso, true);
            }
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;
            var lista = EmpleadosBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                Assert.Fail();

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExistenciaEmpeadosTest()
        {
            Assert.Fail();
        }
    }
}