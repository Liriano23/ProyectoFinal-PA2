using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del Empleado")]
        [MinLength(3, ErrorMessage = "El nombre es demasiado corto")]
        public string NombreSuplidor { get; set; }

        [Required(ErrorMessage = "Debe ingrear el apellido del Empleado")]
        [MinLength(3, ErrorMessage = "El apellido es demasiado corto")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre de la compañia")]
        [MinLength(3, ErrorMessage = "El nombre de la compañia es demasiado corto")]
        public string NombreCompañia { get; set; }

        [Required(ErrorMessage = "Debe ingresar la direccion del Suplidor")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar el telefono del Suplidor en caso de no tener inserte N/A")]
        [Phone]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar el celular del Suplidor en caso de no tener inserte N/A")]
        [Phone]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Ciudad del Suplidor")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Debe ingresar el email del Suplidor.")]
        [EmailAddress]
        public string Email { get; set; }



        [Required(ErrorMessage = "Debe ingresar la fecha de ingreso del Suplidor al sistema")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el usuario que esta agregando el Suplidor")]
        public int UsuariosId { get; set; }
        public Usuarios Usuarios { get; set; }

        public ICollection<Productos> Productos { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            NombreSuplidor = string.Empty;
            Apellidos = string.Empty;
            NombreCompañia = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Ciudad = string.Empty;
            Email = string.Empty;
            FechaIngreso = DateTime.Now;
            UsuariosId = 0;
        }
    }
}
