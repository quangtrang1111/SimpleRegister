using Microsoft.Extensions.Options;
using SimpleRegister.Application.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRegister.Infrastructure.Email
{
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpSettings _settings;

        public SmtpEmailService(IOptions<SmtpSettings> options)
        {
            _settings = options.Value;
        }

        private SmtpClient CreateSMTPClient()
        {
            return new SmtpClient()
            {
                Host = _settings.Host,
                Port = _settings.Port,
                EnableSsl = _settings.EnableSsl,
                Credentials = new NetworkCredential(_settings.Username, _settings.Password)
            };
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var email = new MailMessage
                {
                    From = new MailAddress(_settings.FromEmail, _settings.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                    BodyEncoding = Encoding.UTF8
                };
                email.To.Add(toEmail);

                using var smtpClient = CreateSMTPClient();
                await smtpClient.SendMailAsync(email);
            }
            catch (Exception e)
            {
                throw new Exception($"Can not send email to '{toEmail}'!", e);
            }
        }
    }
}
