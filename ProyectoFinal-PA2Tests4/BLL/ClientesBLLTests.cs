using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using ProyectoFinal_PA2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();

            clientes.ClienteId = 1;
            clientes.Nombres = "Enmanuel";
            clientes.Apellidos = "Gonzalez liriano";
            clientes.Cedula = "888-888-888";
            clientes.Sexo = "masculino";
            clientes.Direccion = "Deep Park";
            clientes.Telefono = "888-888-888";
            clientes.Celular = "888-888-888";
            clientes.Email = "lol";
            clientes.FechaNacimiento = DateTime.Now;
            clientes.FechaIngreso = DateTime.Now;
            clientes.UsuariosId = 0;

            paso = ClientesBLL.Guardar(clientes);
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
            Clientes clientes = new Clientes();

            clientes.ClienteId = 0;
            clientes.Nombres = "Enmanuel";
            clientes.Apellidos = "Gonzalez liriano";
            clientes.Cedula = "888-888-888";
            clientes.Sexo = "masculino";
            clientes.Direccion = "Deep Park";
            clientes.Telefono = "888-888-888";
            clientes.Celular = "888-888-888";
            clientes.Email = "lol";
            clientes.FechaNacimiento = DateTime.Now;
            clientes.FechaIngreso = DateTime.Now;
            clientes.UsuariosId = 0;

            paso = ClientesBLL.Insertar(clientes);
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
            Clientes clientes = new Clientes();

            clientes.ClienteId = 1;
            paso = ClientesBLL.Eliminar(clientes.ClienteId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = true;

            var clientes = ClientesBLL.Buscar(1);

            if (clientes != null)
            {
                paso = true;
                Assert.AreEqual(paso, true);
            }
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;
            var lista = ClientesBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                Assert.Fail();

            Assert.AreEqual(paso, true);
        }
    }
}