using XandaDeck.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XandaDeck.Core.Services
{
    public interface IEmailSender
    {
        string SendEmailAsync(EmailRequest request, List<string> cc = null);
        Task<string> SendEmailAsync(string email, string code, string message);
    }
}
