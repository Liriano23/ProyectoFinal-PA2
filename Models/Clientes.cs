using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required (ErrorMessage = "Debe ingresar el nombre del cliente")]
        [MinLength (3, ErrorMessage ="El nombre es demasiado corto")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Debe ingrear el apellido del cliente")]
        [MinLength(3, ErrorMessage = "El apellido es demasiado corto")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Debe ingresar el apellido del cliente")]
        [MinLength(11, ErrorMessage = "El formato de la cedula es incorrecto")]
        [MaxLength(11, ErrorMessage = "El formato de la cedula es incorrecto")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe ingresar el sexo del cliente")]
        [MinLength(3, ErrorMessage ="Debe ingresar el sexo del cliente")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Debe ingresar la direccion del cliente")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar el telefono del cliente en caso de no tener inserte N/A")]
        [Phone]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar el celular del cliente en caso de no tener inserte N/A")]
        [Phone]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Debe ingresar el email del cliente.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de nacimieneto del cliente")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha de ingreso del cliente al sistema")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el usuario que esta agregando al cliente")]
        public int UsuariosId { get; set; }
        public Usuarios Usuarios { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Sexo = string.Empty;
            Direccion = string.Empty;
            Sexo = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            FechaNacimiento = DateTime.Now;
            FechaIngreso = DateTime.Now;
            UsuariosId = 0;
        }
    }
}
