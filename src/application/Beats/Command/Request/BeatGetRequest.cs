using MediatR;
using src.application.Beats.Command.Response;


namespace src.application.Beats.Command.Request
{

    public class BeatGetRequest : IRequest<List<BeatCreateResponse>>
    {
        // Nenhuma propriedade necessária, pega tudo
    }
}