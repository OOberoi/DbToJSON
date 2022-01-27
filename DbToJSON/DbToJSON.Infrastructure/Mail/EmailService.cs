using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using DbToJSON.Application.Contracts.Infrastructure;
using DbToJSON.Application.Models.Mail;
using Microsoft.Extensions.Logging;

namespace DbToJSON.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        Task<bool> IEmailService.SendEmailAsync(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
