using System;
using System.Net;
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
        public ILogger<EmailService> _logger { get; }

        public EmailService(EmailSettings emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings;
            _logger = logger;   
        }
        public async Task<bool> SendEmailAsync(Email email)
        {
            try
            {
                var client = new SendGridClient(_emailSettings.ApiKey);
                var subject = email.Subject;
                var to = new EmailAddress(email.To);
                var body = email.Body;

                var from = new EmailAddress
                {
                    Email = _emailSettings.FromAddress,
                    Name = _emailSettings.FromName
                };

                var Message = MailHelper.CreateSingleEmail(from, to, subject, body, body);
                var response = await client.SendEmailAsync(Message);

                _logger.LogInformation("Email was sent successfully!");

                if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                _logger.LogInformation("Email failed!");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Mail cound not be sent!");
                return false;
            }

        }
    }
}
