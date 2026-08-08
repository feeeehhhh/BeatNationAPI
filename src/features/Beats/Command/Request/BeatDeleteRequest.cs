using MediatR;

namespace src.features.Beats.Command.Request
{
    public record BeatDeleteRequest(
        Guid Id
    ) : IRequest;
}