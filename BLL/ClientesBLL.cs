using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            if (!Existe(clientes.ClienteId))
                return Insertar(clientes);
            else
                return  Modificar(clientes);
        }

        public static bool Existe(int id)
        {
            var encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Clientes.Any(x => x.ClienteId == id);
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
        public static bool Insertar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();
            
            try
            {
                db.Clientes.Add(clientes);
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

        public static bool Modificar(Clientes clientes)
        {
            bool paso = false;
            Contexto db = new Contexto();
            
            try
            {
                db.Entry(clientes).State = EntityState.Modified;
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
                var cliente = db.Clientes.Find(id);

                if(cliente != null)
                {
                    db.Clientes.Remove(cliente);
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

        public static Clientes Buscar(int id)
        {
            Clientes cliente = new Clientes();
            Contexto db = new Contexto();

            try
            {
                cliente = db.Clientes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return cliente;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto db = new Contexto();
            
            try
            {
                lista = db.Clientes.Where(criterio).ToList();
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

        public static bool ExistenciaClientes(int id)
        {
            bool existe = false;
            Contexto db = new Contexto();
            try
            {
                existe= db.Clientes.Any( x=> x.ClienteId == id);
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
