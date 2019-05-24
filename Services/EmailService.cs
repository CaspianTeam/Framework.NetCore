using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CaspianTeam.Framework.NetCore.Models.Frameworks.Services.EmailService;
using Microsoft.Extensions.Options;

namespace CaspianTeam.Framework.NetCore.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }

    public class EmailService : IEmailService
    {
        private EmailOptionsModel EmailOptions { get; }
        public EmailService(IOptions<EmailOptionsModel> optionsAccessor)
        {
            EmailOptions = optionsAccessor.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient
            {
                Port = EmailOptions.Port,
                Host = EmailOptions.Host,
                EnableSsl = true,
                Timeout = EmailOptions.Timeout,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(EmailOptions.Username, EmailOptions.Password)
            };

            var mail = new MailMessage(EmailOptions.Email, email)
            {
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true,
                Subject = subject,
                Body = htmlMessage
            };

            await client.SendMailAsync(mail);
        }

    }
}
