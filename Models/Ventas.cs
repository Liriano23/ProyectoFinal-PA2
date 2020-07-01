using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_PA2.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }

        [Required (ErrorMessage ="Debe seleccionaar el cliente Id")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el Id del empleado")]
        public int EmpleadoId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaEmision { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el subtotal del de la venta")]
        public decimal SubTotal { get; set; }

        public double ITBIS { get; set; }

        public decimal Descuento { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el valor total de la venta")]
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> Detalle { get; set; }

        public int UsuariosId { get; set; }
        public Usuarios Usuarios { get; set; }

        public Ventas()
        {
            VentaId = 0;
            ClienteId = 0;
            EmpleadoId = 0;
            FechaEmision = DateTime.Now;
            SubTotal = 0;
            ITBIS = 0;
            Descuento = 0;
            Total = 0;
            Detalle = new List<VentasDetalle>();
            UsuariosId = 0;
        }
    }
}
