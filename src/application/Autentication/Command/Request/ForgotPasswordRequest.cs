using MediatR;

namespace src.application.Autentication.Command.Request
{
    public sealed record ForgotPasswordRequest(
     string Email
 ) : IRequest;
}