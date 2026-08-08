using MediatR;
using src.features.Beats.Command.Response;


namespace src.features.Beats.Command.Request
{

    public class BeatGetRequest : IRequest<List<BeatCreateResponse>>
    {
        // Nenhuma propriedade necessária, pega tudo
    }
}