

using src.application.Autentication.Command.Response;
using MediatR;

namespace src.application.Autentication.Command.Request
{
    public class LoginUserRequest : IRequest<TokenResponseDto>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}