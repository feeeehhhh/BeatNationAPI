using MediatR;

namespace BeatNationAPI.Application.Licencas.Command.Request
{
    public record LicencaDeleteRequest(Guid Id): IRequest;

}