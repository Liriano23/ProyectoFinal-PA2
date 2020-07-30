using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinal_PA2.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required (ErrorMessage = "Debe ingresar el nombre del usuario.")]
        [MinLength(3, ErrorMessage ="El nombre es demasiado corto")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Debe ingresar el apellido del usuario.")]
        [MinLength(3, ErrorMessage = "El apellido es demasiado corto")]
        public string Apellidos { get; set; }

        [Required (ErrorMessage = "Debe ingresar la Cedula del usuario")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{11}$", ErrorMessage = "Por favor ingrese un No. de cédula válido")]
        [MinLength(11, ErrorMessage = "El formato de la cedula es demasiado corto")]
        [MaxLength (11,ErrorMessage = "Ha excedido la cantidad de numeros de una cedula")]
        public string Cedula { get; set; }

        [Required (ErrorMessage = "Debe elegir el sexo del usuario")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Debe ingresar el telefono del usuario")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10}$", ErrorMessage = "Por favor ingrese un No. de teléfono válido")]
        [MinLength (10, ErrorMessage = "Formato incorrecto, debe ingresar el teléfono completo")]
        [MaxLength(10, ErrorMessage = "Formato incorrecto, ha excedido la cantidad maxima de caracteres de un N° telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar el celular del usuario")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10}$", ErrorMessage = "Por favor ingrese un No. de celular válido")]
        [MinLength(10, ErrorMessage = "Formato incorrecto, debe ingresar el celular completo")]
        [MaxLength(10, ErrorMessage = "Formato incorrecto, ha excedido la cantidad maxima de caracteres de un  N° celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Debe ingresar la direccion del usuario")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar el email del usuario")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el tipo de usuario")]
        public string TipoUsuario { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la fecha de ingreso del usuario")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime FechaIngreso { get; set; }

        [Required (ErrorMessage = "Debe ingresar el nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Debe ingresar la contraseña del usuario")]
        public string Contrasena { get; set; }

        public ICollection<Clientes> Clientes { get; set; }
        public ICollection<Productos> Productos { get; set; }
        public ICollection<Ventas> Ventas { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            Sexo = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            FechaIngreso = DateTime.Now;
            TipoUsuario = string.Empty;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
        }

        public static string Encriptar(string cadenaEncriptada)
        {
            if (!string.IsNullOrEmpty(cadenaEncriptada))
            {
                string resultado = string.Empty;
                byte[] encryted = Encoding.Unicode.GetBytes(cadenaEncriptada);
                resultado = Convert.ToBase64String(encryted);

                return resultado;
            }
            return string.Empty;
        }

        public static string DesEncriptar(string cadenaDesencriptada)
        {
            if (!string.IsNullOrEmpty(cadenaDesencriptada))
            {
                string resultado = string.Empty;
                byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
                resultado = System.Text.Encoding.Unicode.GetString(decryted);

                return resultado;
            }

            return string.Empty;
        }
    }
}
