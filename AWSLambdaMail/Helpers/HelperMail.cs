using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AWSLambdaMail.Helpers
{
    public class HelperMail
    {
        public async Task SendMailAsync
            (string para, string asunto, string mensaje)
        {
            MailMessage mail = this.ConfigureMailMessage(para, asunto, mensaje);
            SmtpClient client = this.ConfigureSmtpClient();
            await client.SendMailAsync(mail);
        }

        private MailMessage ConfigureMailMessage
            (string para, string asunto, string mensaje)
        {
            MailMessage mailMessage = new MailMessage();
            string email = "mail@mail.com";
            mailMessage.From = new MailAddress(email);
            mailMessage.To.Add(new MailAddress(para));
            mailMessage.Subject = asunto;
            mailMessage.Body = mensaje;
            mailMessage.IsBodyHtml = true;
            return mailMessage;
        }

        private SmtpClient ConfigureSmtpClient()
        {
            string user = "";
            string password = "";
            string host = "smtp.gmail.com";
            int port = 587; //587
            bool enableSSL = true;
            bool defaultCredentials = false;
            SmtpClient client = new SmtpClient();
            client.Host = host;
            client.Port = port;
            client.EnableSsl = enableSSL;
            client.UseDefaultCredentials = defaultCredentials;
            NetworkCredential credentials = 
                new NetworkCredential(user, password);
            client.Credentials = credentials;
            return client;
        }
    }
}
