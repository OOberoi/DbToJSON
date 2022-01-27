using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using DbToJSON.Application.Contracts.Infrastructure;
using DbToJSON.Application.Models.Mail;
using Microsoft.Extensions.Logging;

namespace DbToJSON.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> logger { get; }

        public EmailService(EmailSettings emailSettings, ILogger<EmailService> _logger)
        {
            _emailSettings = emailSettings;
            logger = _logger;   
        }
        public Task<bool> IEmailService.SendEmailAsync(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);

            throw new NotImplementedException();
        }
    }
}
