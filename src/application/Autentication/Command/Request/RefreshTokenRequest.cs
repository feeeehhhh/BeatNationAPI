
using src.application.Autentication.Command.Response;
using MediatR;

namespace src.application.Autentication.Command.Request
{
    public sealed class RefreshTokenRequest : IRequest<TokenResponseDto>
    {
        public string? RefreshToken { get; set; }

    }
}