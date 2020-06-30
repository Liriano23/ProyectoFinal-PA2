using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del producto")]
        [MinLength(3,ErrorMessage = "El nombre del producto es muy corto")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage="Debe ingresar la marca del producto")]
        [MinLength(3,ErrorMessage = "La marca del producto debe contener al menos 3 letras")]
        public string MarcaProducto { get; set; }

        [Required(ErrorMessage="Debe ingresar la cantidad del producto en el inventario")]
        [Range(0,10000, ErrorMessage = "Ingrese una cantidad valida")]
        public int Inventario { get; set; }

        [Required(ErrorMessage="Debe ingresar el precio de venta del producto")]
        public decimal PrecioDeVenta { get; set; }

        [Required(ErrorMessage = "Debe ingresar el precio de compra del producto")]
        public decimal PrecioDeCompra { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de ingreso del producto")]
        public DateTime FechaIngreso { get; set; }

       // [ForeignKey("Suplidores")]
        public int SuplidorId { get; set; }

        //[ForeignKey("Categorias")]
        public int CategoriaId { get; set; }


        [Required(ErrorMessage = "Debe ingresar el usuario que esta agregando al cliente")]
        public int UsuariosId { get; set; }
        public virtual Usuarios Usuarios { get; set; }

        public Productos()
        {
            ProductoId = 0;
            NombreProducto = string.Empty;
            MarcaProducto = string.Empty;
            Inventario = 0;
            FechaIngreso = DateTime.Now;
            UsuariosId = 0;
            SuplidorId = 0;
            CategoriaId = 0;
            PrecioDeCompra = 0;
            PrecioDeVenta = 0;
        }
    }
}
