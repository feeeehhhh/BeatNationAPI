using MediatR;

namespace BeatNationAPI.Application.Autentication.Command.Request
{
    public sealed record ForgotPasswordRequest(
     string Email
 ) : IRequest;
}