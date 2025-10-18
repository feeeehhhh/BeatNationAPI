using MediatR;
using BeatNationAPI.Application.Licencas.Command.Response;
using System.Collections.Generic;

namespace BeatNationAPI.Application.Command.Licencas.Request
{
    public class LicencaGetRequest: IRequest<List<LicencaCreateResponse>>
    {
        // Nenhuma propriedade necessária, pega tudo
    }
}
