using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal_PA2.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            if(!Existe(productos.ProductoId))
                return Insertar(productos);
            else
                return Modificar(productos);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db= new Contexto();
            
            try
            {
                encontrado = db.Productos.Any(x=> x.ProductoId == id);   
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static bool Insertar(Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();
           try
           {
               db.Productos.Add(productos);
               paso = (db.SaveChanges() > 0);
           }
           catch(Exception)
           {
               throw;
           }
           finally
           {
               db.Dispose();
           }
           return paso;
        }

        public static bool Modificar(Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(productos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch(Exception)
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
                var productos = db.Productos.Find(id);

                if(productos != null)
                {
                    db.Productos.Remove(productos);
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Productos Buscar(int id)
        {
            Productos productos = new Productos();
            Contexto db = new Contexto();

            try
            {
                productos = db.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return productos;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            Contexto db = new Contexto();
            
            try
            {
                lista = db.Productos.Where(criterio).ToList();
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

        public static bool ExistenciaProductos(int id)
        {
            bool existe = false;
            Contexto db = new Contexto();
            try
            {
                existe = db.Productos.Any(x => x.ProductoId == id);
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

        public static bool DisminuirInventario(int id, int cantidad)
        {
            bool paso = false;
            Contexto db = new Contexto();
            var producto = db.Productos.Find(id);

            if (producto != null)
            {
                try
                {
                    if (producto.Inventario > 0)
                        producto.Inventario = (producto.Inventario - cantidad);

                    db.Entry(producto).State = EntityState.Modified;
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
            }

            return paso;
        }

        public static bool AumentarInventario(int id, int cantidad)
        {
            bool paso = false;
            Contexto db = new Contexto();
            var producto = db.Productos.Find(id);

            if (producto != null)
            {
                try
                {
                    if (producto.Inventario > 0)
                        producto.Inventario = (producto.Inventario + cantidad);


                    db.Entry(producto).State = EntityState.Modified;
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
            }

            return paso;
        }
    }
}