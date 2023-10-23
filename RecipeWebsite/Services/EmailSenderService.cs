using Microsoft.Extensions.Options;
using RecipeWebsite.Helpers;
using System.Net.Mail;
using System.Net;
using RecipeWebsite.Interfaces;

namespace RecipeWebsite.Services
{
    public class EmailSenderService : IEmailSenderInterface
    {
        private readonly ILogger<EmailSenderService> _logger;

        public EmailHelper Options { get; set; }
        public EmailSenderService(IOptions<EmailHelper> options, ILogger<EmailSenderService> logger)
        {
            Options = options.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string Email, string Subject, string Message)
        {
            if (string.IsNullOrEmpty(Options.Host) || string.IsNullOrEmpty(Options.Username) || string.IsNullOrEmpty(Options.Password))
            {
                throw new Exception("Null SMTP_Credientials");
            }
            await Execute(Options.Host, Options.Username, Options.Password, Email, Subject, Message);
        }

        private Task Execute(string host, string username, string password, string toEmail, string subject, string message)
        {
            var client = new SmtpClient(host, 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(username, password)
            };
            return client.SendMailAsync(
                   new MailMessage(from: "DoNotReply < " + username + " > ",
                                   to: toEmail,
                                   subject,
                                   message
                                   ));
        }
    }
}
