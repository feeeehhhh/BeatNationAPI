using BeatNationAPI.Application.Command.Licencas.Response;
using MediatR;


namespace BeatNationAPI.Application.Command.Licencas.Request
{
    public class LicencaGetRequest: IRequest<List<LicencaCreateResponse>>
    {
        // Nenhuma propriedade necessária, pega tudo
    }
}
