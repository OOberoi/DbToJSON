using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbToJSON.Application.Models.Mail;

namespace DbToJSON.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
