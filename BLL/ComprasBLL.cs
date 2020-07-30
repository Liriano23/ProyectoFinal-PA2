using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL
{
    public class ComprasBLL
    {
        public static bool Guardar(Compras compras)
        {
            if (!Existe(compras.CompraId))
                return Insertar(compras);
            else
                return Modificar(compras);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Compras.Any(x => x.CompraId == id);
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

        public static bool Insertar(Compras compras)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Compras.Add(compras);
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

        public static bool Modificar(Compras compras)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Database.ExecuteSqlRaw($"Delete From ComprasDetalle where CompraId ={ compras.CompraId}");
                foreach (var item in compras.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(compras).State = EntityState.Modified;
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
                var compras = db.Compras.Find(id);

                if (compras != null)
                {
                    db.Compras.Remove(compras);
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

        public static Compras Buscar(int id)
        {
            Contexto db = new Contexto();
            Compras compras = new Compras();

            try
            {
                compras = db.Compras
                    .Where(x => x.CompraId == id)
                    .Include(d => d.Detalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return compras;
        }

        public static List<Compras> GetList(Expression<Func<Compras, bool>> criterio)
        {
            List<Compras> lista = new List<Compras>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Compras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
