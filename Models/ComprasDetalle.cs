using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.Models
{
    public class ComprasDetalle
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Id del Producto")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Id de la compra")]
        public int ComprasId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad Producto")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe ingresar el precio del Producto")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Ingrese valor del producto")]
        public decimal Valor { get; set; }

        public ComprasDetalle()
        {
            Id = 0;
            ProductoId = 0;
            ComprasId = 0;
            Cantidad = 0;
            Precio = 0;
            Valor = 0;
        }

    }
}
