using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProyectoFinal_PA2.BLL
{
    public class EmailService
    {
        public static string SendMail(string email)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("exampleBlazor@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Correo de recuperación de contraseña";
                    mail.Body = "<h1>Se ha hecho una solicitud desde el Sistema Repuestos Rafa para repurar su contraseña." +
                        "<br/> Presione el siguiente enlace para recuperar su contraseña </h1>" +
                        "<a href= 'https://localhost:44311/RecoverPassword'> Link de recuperación </a>";

                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("exampleBlazor@gmail.com", "@12345678900");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        return "Correo enviado";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
