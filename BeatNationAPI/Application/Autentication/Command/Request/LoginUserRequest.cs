

using BeatNationAPI.Application.Autentication.Command.Response;
using MediatR;

namespace BeatNationAPI.Application.Autentication.Command.Request
{
    public class LoginUserRequest : IRequest<TokenResponseDto>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}