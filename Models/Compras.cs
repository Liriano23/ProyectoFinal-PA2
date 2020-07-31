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
        public int CompraId { get; set; }

        [Required(ErrorMessage = "Debe seleccionaar el Suplidor Id")]
        public int SuplidorId { get; set; }
        public Suplidores Suplidores { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeCompra { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el subtotal del de la Compra")]
        public decimal SubTotal { get; set; }

        public double ITBIS { get; set; }

        public decimal Descuento { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el valor total de la Compra")]
        public decimal Total { get; set; }

        [ForeignKey("CompraId")]
        public virtual List<ComprasDetalle> Detalle { get; set; }

        public int UsuariosId { get; set; }
        public Usuarios Usuarios { get; set; }

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
