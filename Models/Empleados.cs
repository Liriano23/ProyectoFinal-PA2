using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.Models
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del Empleado")]
        [MinLength(3, ErrorMessage = "El nombre es demasiado corto")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Debe ingrear el apellido del Empleado")]
        [MinLength(3, ErrorMessage = "El apellido es demasiado corto")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Debe ingresar el apellido del Empleado")]
        [MinLength(11, ErrorMessage = "El formato de la cedula es incorrecto")]
        [MaxLength(11, ErrorMessage = "El formato de la cedula es incorrecto")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe ingresar la direccion del Empleado")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar el telefono del Empleado en caso de no tener inserte N/A")]
        [Phone]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar el celular del Empleado en caso de no tener inserte N/A")]
        [Phone]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Debe ingresar el email del Empleado.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingrear el Cargo del Empleado")]
        [MinLength(3, ErrorMessage = "El Cargo es demasiado corto")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Sueldo del empleado")]
        public decimal Sueldo { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de nacimieneto del Empleado")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de ingreso del Empleado al sistema")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el usuario que esta agregando el empleado")]
        public int UsuariosId { get; set; }
        public Usuarios Usuarios { get; set; }

        public ICollection<Ventas> Ventas { get; set; }

        public Empleados()
        {
            EmpleadoId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Cargo = string.Empty;
            Sueldo = 0;
            FechaNacimiento = DateTime.Now;
            FechaIngreso = DateTime.Now;
            UsuariosId = 0;
        }
    }
}
