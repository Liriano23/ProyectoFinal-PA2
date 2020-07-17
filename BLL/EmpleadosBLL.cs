using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL
{
    public class EmpleadosBLL
    {
        public static bool Guardar(Empleados empleados)
        {
            if (!Existe(empleados.EmpleadoId))
                return Insertar(empleados);
            else
                return Modificar(empleados);
        }

        public static bool Existe(int id)
        {
            var encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Empleados.Any(x => x.EmpleadoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
        public static bool Insertar(Empleados empleados)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Empleados.Add(empleados);
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Empleados empleados)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(empleados).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var empleados = db.Empleados.Find(id);

                if (empleados != null)
                {
                    db.Empleados.Remove(empleados);
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Empleados Buscar(int id)
        {
            Empleados empleados = new Empleados();
            Contexto db = new Contexto();

            try
            {
                empleados = db.Empleados.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return empleados;
        }

        public static List<Empleados> GetList(Expression<Func<Empleados, bool>> criterio)
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Empleados.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool ExistenciaEmpeados(int id)
        {
            bool existe = false;
            Contexto db = new Contexto();
            try
            {
                existe = db.Empleados.Any(x => x.EmpleadoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return existe;
        }
    }
}
