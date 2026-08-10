using MediatR;

namespace src.application.Beats.Command.Request
{
    public record BeatDeleteRequest(
        Guid Id
    ) : IRequest;
}