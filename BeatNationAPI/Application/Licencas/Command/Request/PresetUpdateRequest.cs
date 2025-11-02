
using BeatNationAPI.Common.Responses;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command.Request
{
    public record PresetUpdateRequest(
    Guid Id,
    string Nome,
    string Descricao,
    Guid? OwnerId
    ) : IRequest<Response<Guid>>;
}
