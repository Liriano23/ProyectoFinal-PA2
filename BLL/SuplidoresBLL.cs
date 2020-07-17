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
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidores)
        {
            if (!Existe(suplidores.SuplidorId))
                return Insertar(suplidores);
            else
                return Modificar(suplidores);
        }

        public static bool Existe(int id)
        {
            var encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Suplidores.Any(x => x.SuplidorId == id);
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
        public static bool Insertar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Suplidores.Add(suplidores);
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

        public static bool Modificar(Suplidores suplidores)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(suplidores).State = EntityState.Modified;
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
                var suplidores = db.Suplidores.Find(id);

                if (suplidores != null)
                {
                    db.Suplidores.Remove(suplidores);
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

        public static Suplidores Buscar(int id)
        {
            Suplidores suplidores = new Suplidores();
            Contexto db = new Contexto();

            try
            {
                suplidores = db.Suplidores.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return suplidores;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Suplidores.Where(criterio).ToList();
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

        public static bool ExistenciaSuplidores(int id)
        {
            bool existe = false;
            Contexto db = new Contexto();
            try
            {
                existe = db.Suplidores.Any(x => x.SuplidorId == id);
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
