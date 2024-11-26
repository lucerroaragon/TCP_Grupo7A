using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("18cbac92376f3b", "37f710ee2e786c");
            server.EnableSsl = true;
            server.Host = "sandbox.smtp.mailtrap.io";
            server.Port = 2525;
        }
        public void armarCorreo(string destinatario, string asunto, int codigo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@puntosreciclaje.com.ar");
            email.To.Add(destinatario);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>¡Bienvenido a Puntos de Reciclaje!</h1><br><p>Gracias por registrarte en nuestra plataforma. A partir de ahora podrás disfrutar de todos los beneficios que tenemos para ofrecerte.</p><br><p>¡Bienvenido a la comunidad de Recicladores!</p><br><p>Código de verificación: " + codigo + "</p><br><p>Saludos cordiales,</p><br><p>Equipo de Puntos de Reciclaje</p>";
            //email.Body = cuerpo;
        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
