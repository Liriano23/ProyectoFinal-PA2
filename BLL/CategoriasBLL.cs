using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL
{
    public class CategoriasBLL
    {
         public static bool Guardar(Categorias categorias)
        {
            if (!Existe(categorias.CategoriaId))
                return Insertar(categorias);
            else
                return Modificar(categorias);
        }

        public static bool Existe(int id)
        {
            var encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Categorias.Any(x => x.CategoriaId == id);
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
        public static bool Insertar(Categorias categorias)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Categorias.Add(categorias);
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

        public static bool Modificar(Categorias categorias)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(categorias).State = EntityState.Modified;
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
                var categorias = db.Categorias.Find(id);

                if (categorias != null)
                {
                    db.Categorias.Remove(categorias);
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

        public static Categorias Buscar(int id)
        {
            Categorias categorias = new Categorias();
            Contexto db = new Contexto();

            try
            {
                categorias = db.Categorias.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return categorias;
        }

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> criterio)
        {
            List<Categorias> lista = new List<Categorias>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Categorias.Where(criterio).ToList();
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

        public static bool Existenciacategorias(int id)
        {
            bool existe = false;
            Contexto db = new Contexto();
            try
            {
                existe = db.Categorias.Any(x => x.CategoriaId == id);
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
