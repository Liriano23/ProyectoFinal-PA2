using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;
using System.Security.Cryptography.X509Certificates;

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
                usuarios.Contrasena = Usuarios.Encriptar(usuarios.Contrasena);
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
                usuarios.Contrasena = Usuarios.Encriptar(usuarios.Contrasena);
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
                usuarios.Contrasena = Usuarios.DesEncriptar(usuarios.Contrasena);
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

        public static bool GetExistenciaYClaveUsuario(string NombreUsuario, string clave)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                paso = db.Usuarios.Any(A => A.NombreUsuario == NombreUsuario && A.Contrasena == Usuarios.Encriptar(clave));
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static string GetTipoUsuario(string Usuario)
        {

            string nivel = "";
            Contexto db = new Contexto();

            try
            {
                nivel = db.Usuarios.Where(A => A.NombreUsuario.Equals(Usuario)).Select(A => A.TipoUsuario).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return nivel;
        }

        public static bool ExisteEmail(string mail)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                paso = db.Usuarios.Any(x => x.Email == mail);
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

        public static bool ChangePassword(string mail, string newPassword)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var usuario = BuscarPorEmail(mail);

                if (usuario != null)
                {
                    usuario.Contrasena = newPassword;
                    int id = usuario.UsuarioId;
                    
                    Modificar(usuario); // Se modifica el usuario
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

        public static Usuarios BuscarPorEmail (string email)
        {
            Usuarios usuarios = new Usuarios();
            List<Usuarios> lista = new List<Usuarios>();

            Contexto db = new Contexto();

            try
            {
                lista = GetList(x => true);
                foreach(var item in lista)
                {
                    if (item.Email == email)
                    {
                        usuarios = Buscar(item.UsuarioId);
                        break;
                    }
                        
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
            return usuarios;
        }

    }
}
