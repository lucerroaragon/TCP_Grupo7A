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
        public void armarCorreo(string destinatario, string asunto, int codigo, string Cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@puntosreciclaje.com.ar");
            email.To.Add(destinatario);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = 
            email.Body = Cuerpo;
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
