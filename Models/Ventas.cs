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
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el Id del empleado")]
        [ForeignKey("Empleados")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int EmpleadoId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaEmision { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el subtotal del de la venta")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public decimal SubTotal { get; set; }

        [Required (ErrorMessage ="Debe ingresar el ITBIS sino aplica es 0")]
        [Range(0,10000, ErrorMessage = "Ingrese una cantidad valida")]
        public double ITBIS { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Descuento sino aplica es 0")]
        [Range(0, 1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public decimal Descuento { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el valor total de la venta")]
        [Range(0, 1000000, ErrorMessage = "Ingrese una cantidad valida")]
        public decimal Total { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> Detalle { get; set; }

        [ForeignKey("Usuarios")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int UsuariosId { get; set; }

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
