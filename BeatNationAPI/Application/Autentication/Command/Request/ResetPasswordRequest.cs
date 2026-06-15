using MediatR;

namespace BeatNationAPI.Application.Autentication.Command.Request
{
    public class ResetPasswordRequest : IRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}