using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal_PA2.BLL;
using ProyectoFinal_PA2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal_PA2.BLL.Tests
{
    [TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Ventas ventas = new Ventas();

            ventas.VentaId = 3;
            ventas.ClienteId = 0;
            ventas.EmpleadoId = 0;
            ventas.FechaEmision = DateTime.Now;
            ventas.SubTotal = 400;
            ventas.ITBIS = 0.18;
            ventas.Descuento = 10;
            ventas.Total = 350;

            paso = VentasBLL.Guardar(ventas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;

            paso = VentasBLL.Existe(1);

            if (paso)
                Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Ventas ventas = new Ventas();

            ventas.VentaId = 0;
            ventas.ClienteId = 0;
            ventas.EmpleadoId = 0;
            ventas.FechaEmision = DateTime.Now;
            ventas.SubTotal = 400;
            ventas.ITBIS = 0.18;
            ventas.Descuento = 10;
            ventas.Total = 350;

            paso = VentasBLL.Insertar(ventas);
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
            Ventas ventas = new Ventas();

            ventas.VentaId = 1;
            paso = VentasBLL.Eliminar(ventas.VentaId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = true;

            var ventas = VentasBLL.Buscar(1);

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
            var lista = UsuariosBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                Assert.Fail();

            Assert.AreEqual(paso, true);
        }
    }
}