using BeatNationAPI.Common.Responses;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command.Request
{
    public record PresetDeleteRequest(
        Guid Id
    ) : IRequest<Response<Guid>>;
}