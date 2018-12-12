using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Utilities
{
    public class Email
    {
        private string Host { get; } = "smtp.task.com.br";
        private int Porta { get; } = 587;
        private string Username { get; } = "sou@petsaver.com.br";
        private string Senha { get; } = "Pet@!Sucesso2019";

        public void EnviarEmail(string aAssunto, string aConteudo, string aDestinatario, bool isHtml)
        {
            if (string.IsNullOrEmpty(aAssunto) || string.IsNullOrEmpty(aConteudo) || string.IsNullOrEmpty(aDestinatario))
            {
                return;
            }

            MailMessage mail = new MailMessage(Username, aDestinatario, aAssunto, aConteudo)
            {
                IsBodyHtml = isHtml
            };

            SmtpClient client = new SmtpClient(Host, Porta)
            {
                Credentials = new NetworkCredential(Username, Senha)
            };

            client.Send(mail);
        }

    }
}
