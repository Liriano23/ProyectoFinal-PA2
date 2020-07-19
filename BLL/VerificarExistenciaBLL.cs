using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinal_PA2.DAL;
using ProyectoFinal_PA2.Models;

namespace ProyectoFinal_PA2.BLL
{
    public class VerificarExistenciaBLL
    {

        public static bool VerificarExistencia(object obj, int id)
        {
            Contexto db = new Contexto();
            bool existe = false;

            try
            {
                if (obj != null)
                {
                    if(obj.GetType() == typeof(Usuarios))
                        existe = db.Usuarios.Any(x => x.UsuarioId == id);

                    else if(obj.GetType() == typeof(Clientes))
                        existe = db.Clientes.Any(x => x.ClienteId == id);

                    else if(obj.GetType() == typeof(Productos))
                        existe = db.Productos.Any(x => x.ProductoId == id);

                    else if (obj.GetType() == typeof(Empleados))
                        existe = db.Empleados.Any(x => x.EmpleadoId == id);

                    else if (obj.GetType() == typeof(Categorias))
                        existe = db.Categorias.Any(x => x.CategoriaId == id);

                    else if (obj.GetType() == typeof(Suplidores))
                        existe = db.Suplidores.Any(x => x.SuplidorId == id);
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
            return existe;
        }
    }
}
