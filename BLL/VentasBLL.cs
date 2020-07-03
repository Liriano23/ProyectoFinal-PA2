using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas ventas)
        {
            if (!Existe(ventas.VentaId))
                return Insertar(ventas);
            else
                return Modificar(ventas);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Ventas.Any(x => x.VentaId == id);
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

        public static bool Insertar(Ventas ventas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Ventas.Add(ventas);
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

        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Database.ExecuteSqlRaw($"Delete From VentasDetalle where VentaId ={ ventas.VentaId}");
                foreach(var item in ventas.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(ventas).State = EntityState.Modified;
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
                var ventas = db.Ventas.Find(id);

                if(ventas != null)
                {
                    db.Remove(ventas);
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

        public static Ventas Buscar(int id)
        {
            Contexto db = new Contexto();
            Ventas ventas = new Ventas();

            try
            {
                ventas = db.Ventas
                    .Where(x => x.VentaId == id)
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

            return ventas;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Ventas.Where(criterio).ToList();
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
