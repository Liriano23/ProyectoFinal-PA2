using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.Models
{
    public class Compras
    {
        [Key]
        [Required]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int CompraId { get; set; }

        [Required(ErrorMessage = "Debe seleccionaar el Suplidor Id")]
        public int SuplidorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeCompra { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el subtotal del de la Compra")]
        [Range(0, 1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public decimal SubTotal { get; set; }

        [Required(ErrorMessage = "Debe ingresar el ITBIS sino aplica es 0")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un TIBIS valido")]
        public double ITBIS { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Descuento sino aplica es 0")]
        [Range(0, 1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public decimal Descuento { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el valor total de la Compra")]
        [Range(0, 1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public decimal Total { get; set; }

        [ForeignKey("CompraId")]
        public virtual List<ComprasDetalle> Detalle { get; set; }

        [ForeignKey("Usuarios")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int UsuariosId { get; set; }


        public Compras()
        {
            CompraId = 0;
            SuplidorId = 0;
            FechaDeCompra = DateTime.Now;
            SubTotal = 0;
            ITBIS = 0;
            Descuento = 0;
            Total = 0;
            UsuariosId = 0;
            Detalle = new List<ComprasDetalle>();
        }
        
    }
}
