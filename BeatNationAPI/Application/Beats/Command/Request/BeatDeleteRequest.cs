using MediatR;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public record BeatDeleteRequest(
        Guid Id
    ) : IRequest;
}