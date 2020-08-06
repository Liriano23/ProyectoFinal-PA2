using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using ProyectoFinal_PA2.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class VerificarExistenciaBLLTests
    {
        [TestMethod()]
        public void VerificarExistenciaTest()
        {
            Usuarios usuarios = new Usuarios();
            var usuario = UsuariosBLL.Buscar(1);
            bool paso = false;

            paso = VerificarExistenciaBLL.VerificarExistencia(usuarios, usuario.UsuarioId);

            if (paso)
                Assert.AreEqual(paso, true);
            else
                Assert.Fail();
        }
    }
}