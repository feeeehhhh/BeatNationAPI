using MediatR;

namespace src.application.Autentication.Command.Request
{
    public class ConfirmEmailRequest :IRequest
    {
        public string email { get; set; }
        public string Token { get; set; }
       
    }
}