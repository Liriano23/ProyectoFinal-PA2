using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_PA2.Models
{
    public class VentasDetalle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el id del producto")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el id de la venta")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad del producto")]
        [Range(0,1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe ingresar el precio producto")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public decimal Precio { get; set; }
        
        [Required(ErrorMessage = "Ingrese valor del producto")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public decimal Valor { get; set; }

        public VentasDetalle()
        {
            Id = 0;
            ProductoId = 0;
            VentaId = 0;
            Cantidad = 0;
            Precio = 0;
            Valor = 0;
        }

    }
}
