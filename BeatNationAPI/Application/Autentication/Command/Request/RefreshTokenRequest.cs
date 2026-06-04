
using BeatNationAPI.Application.Autentication.Command.Response;
using MediatR;

namespace BeatNationAPI.Application.Autentication.Command.Request
{
    public sealed class RefreshTokenRequest : IRequest<TokenResponseDto>
    {
        public string? RefreshToken { get; set; }

    }
}