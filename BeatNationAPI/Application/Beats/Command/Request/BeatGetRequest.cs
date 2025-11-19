using MediatR;
using BeatNationAPI.Application.Beats.Command.Response;


namespace BeatNationAPI.Application.Beats.Command.Request
{

    public class BeatGetRequest : IRequest<List<BeatCreateResponse>>
    {
        // Nenhuma propriedade necessária, pega tudo
    }
}