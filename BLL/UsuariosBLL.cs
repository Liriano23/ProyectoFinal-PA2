using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            if (!Existe(usuarios.UsuarioId))
                return Insertar(usuarios);
            else
                return Modificar(usuarios);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Usuarios.Any(x => x.UsuarioId == id);
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

        public static bool Insertar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();
            
            try
            {
                db.Usuarios.Add(usuarios);
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

        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(usuarios).State = EntityState.Modified;
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
                var usuario = db.Usuarios.Find(id);
                if(usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    paso = (db.SaveChanges() >0);
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

        public static Usuarios Buscar(int id)
        {
            Usuarios usuarios = new Usuarios();
            Contexto db = new Contexto();

            try
            {
                usuarios = db.Usuarios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return usuarios;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios,bool>> criterio)
        {
            List<Usuarios> listas = new List<Usuarios>();
            Contexto db = new Contexto();
            
            try
            {
                listas = db.Usuarios.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return listas;
        }

        public static List<Usuarios> GetUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Usuarios.ToList();
            }
            catch (Exception)
            {
                throw ;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool ExistenciaUsuario(int id)
        {
            bool existe = false;
            Contexto db = new Contexto();
            try
            {
                existe = db.Usuarios.Any(x=> x.UsuarioId == id);
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
