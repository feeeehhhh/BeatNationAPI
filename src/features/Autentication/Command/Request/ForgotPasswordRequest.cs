using MediatR;

namespace src.features.Autentication.Command.Request
{
    public sealed record ForgotPasswordRequest(
     string Email
 ) : IRequest;
}