using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 0;
            usuarios.Nombres = "Empleado";
            usuarios.Apellidos = "Empleado";
            usuarios.Cedula = "40215207107";
            usuarios.Sexo = "Masculino";
            usuarios.Telefono = "8098778989";
            usuarios.Celular = "8098778989";
            usuarios.Direccion = "Urb. Brugal";
            usuarios.Email = "empleado@RepuestosRafa.com";
            usuarios.TipoUsuario = "Empleado";
            usuarios.FechaIngreso = DateTime.Now;
            usuarios.NombreUsuario = "Empleado123";
            usuarios.Contrasena = "Empleado123";
            paso = UsuariosBLL.Guardar(usuarios);

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
            Usuarios usuarios = new Usuarios();
            bool paso = false;

            usuarios.UsuarioId = 0;
            usuarios.Nombres = "Empleado";
            usuarios.Apellidos = "Empleado";
            usuarios.Cedula = "40215207107";
            usuarios.Sexo = "Masculino";
            usuarios.Telefono = "8098778989";
            usuarios.Celular = "8098778989";
            usuarios.Direccion = "Urb. Brugal";
            usuarios.Email = "empleado@RepuestosRafa.com";
            usuarios.TipoUsuario = "Empleado";
            usuarios.FechaIngreso = DateTime.Now;
            usuarios.NombreUsuario = "Empleado123";
            usuarios.Contrasena = "Empleado123";
            paso = UsuariosBLL.Guardar(usuarios);

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
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 4;
            paso = UsuariosBLL.Eliminar(usuarios.UsuarioId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = true;

            var usuarios = UsuariosBLL.Buscar(1);

            if (usuarios != null)
            {
                paso = true;
                Assert.AreEqual(paso, true);
            }
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso = false;
            var lista = UsuariosBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                Assert.Fail();

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetExistenciaYClaveUsuarioTest()
        {
            bool paso = false;

            paso = UsuariosBLL.GetExistenciaYClaveUsuario("Admin", "Admin");

            if (paso)
                Assert.AreEqual(paso, true);
            else
                Assert.Fail();
        }

        [TestMethod()]
        public void GetTipoUsuarioTest()
        {
            string nivel = "";
            bool paso = false;

            nivel = UsuariosBLL.GetTipoUsuario("Admin");

            if (nivel.Trim().Length > 0)
                Assert.AreEqual(paso, true);
            else
                Assert.Fail();
        }

        [TestMethod()]
        public void ExisteEmailTest()
        {
            bool paso = false;

            paso = UsuariosBLL.ExisteEmail("admin123@gmail.com");

            if (paso)
                Assert.AreEqual(paso, true);
            else
                Assert.Fail();
        }

        [TestMethod()]
        public void ChangePasswordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarPorEmailTest()
        {
            Assert.Fail();
        }
    }
}