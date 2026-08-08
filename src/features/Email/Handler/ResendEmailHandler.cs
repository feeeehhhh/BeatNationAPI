using src.app.Configurations;
using src.features.Interface.Email.Command;
using Microsoft.Extensions.Options;
using Resend;

namespace src.features.Email.Handler
{

    public class ResendEmailService : IEmailService
    {
        private readonly ResendClient _resendClient;
        private readonly ResendOptions _options;

        public ResendEmailService(IOptions<ResendOptions> options, ResendClient resendClient)
        {
            _options = options.Value;
            _resendClient = resendClient;
        }
        public async Task SendAsync(string to, string subject, string htmlbody)
        {
            Console.WriteLine("Entrou no ResendEmailService");
            var message = new EmailMessage
            {
                From = _options.FromEmail,
                To = to,
                Subject = subject,
                HtmlBody = htmlbody
            };
            message.To.Add(to);
            
            await _resendClient.EmailSendAsync(message);
            
        }

    }
}
