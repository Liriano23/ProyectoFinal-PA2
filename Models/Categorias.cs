using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.Models
{
    public class Categorias
    {
        [Key]
        [Required]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del producto")]
        [MinLength(3, ErrorMessage = "El nombre del producto es muy corto")]
        public string NombreCategoria { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de ingreso del producto")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime FechaIngreso { get; set; }
               
        [Required(ErrorMessage = "Debe ingresar el usuario que esta agregando al cliente")]
        [Range(0, 1000000, ErrorMessage = "Ingrese un Id valido")]
        public int UsuariosId { get; set; }
        public Usuarios Usuarios { get; set; }

        public ICollection<Productos> Productos { get; set; }

        public Categorias()
        {
            CategoriaId = 0;
            NombreCategoria = string.Empty;
            FechaIngreso = DateTime.Now;
            UsuariosId = 0;
        }

    }
}
