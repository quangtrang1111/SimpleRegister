using System.Threading.Tasks;

namespace SimpleRegister.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
