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
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Id del Producto")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Id de la compra")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int CompraId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad Producto")]
        [Range(0, 1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe ingresar el precio del Producto")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Precio valido")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Ingrese valor del producto")]
        [Range(0, 1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public decimal Valor { get; set; }

        public ComprasDetalle()
        {
            Id = 0;
            ProductoId = 0;
            CompraId = 0;
            Cantidad = 0;
            Precio = 0;
            Valor = 0;
        }

    }
}
