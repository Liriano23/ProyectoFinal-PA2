using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.BLL
{
    public class EmailService
    {
        public static string Correo { get; set; }

        public static void SendMail(string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");

            try
            {
              Correo = email;
              mail.From = new MailAddress("exampleBlazor@gmail.com");
              mail.To.Add(email);
              mail.Subject = "Correo de recuperación de contraseña";
              mail.Body = "<p> <strong>Se ha hecho una solicitud desde el Sistema Repuestos Rafa para repurar su contraseña. </strong>" +
                  "<br/> Presione el siguiente enlace para recuperar su contraseña </p>" +
                  "<a href= 'https://localhost:44311/RecoverPassword'> Link de recuperación </a>";

              mail.IsBodyHtml = true;

              smtp.Credentials = new System.Net.NetworkCredential("exampleBlazor@gmail.com", "@12345678900");
              smtp.EnableSsl = true;
              smtp.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smtp.Dispose();
            }
        }
    }
}
