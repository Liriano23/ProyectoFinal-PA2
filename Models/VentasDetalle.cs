using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_PA2.Models
{
    public class VentasDetalle
    {
        [Key]
        [Required]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el id del producto")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el id de la venta")]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad del producto")]
        [Range(0,1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe ingresar el precio producto")]
        public decimal Precio { get; set; }
        
        [Required(ErrorMessage = "Ingrese valor del producto")]
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
