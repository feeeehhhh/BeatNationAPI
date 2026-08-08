
using src.features.Autentication.Command.Response;
using MediatR;

namespace src.features.Autentication.Command.Request
{
    public sealed class RefreshTokenRequest : IRequest<TokenResponseDto>
    {
        public string? RefreshToken { get; set; }

    }
}