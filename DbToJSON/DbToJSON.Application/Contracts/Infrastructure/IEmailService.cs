using DbToJSON.Application.Models.Mail;

namespace DbToJSON.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
