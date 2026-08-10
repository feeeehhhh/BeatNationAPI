namespace src.application.Interface.Email.Command
{
    public interface IEmailService
    {
        Task SendAsync(
            string to,
            string subject,
            string htmlBody
        );
    }
}
