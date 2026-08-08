using src.features.Beats.Command.Response;
using src.Common.Responses;
using MediatR;

namespace src.features.Beats.Command.Request
{
    public record CreateUploadRequest(string UrlFile) : IRequest<Response<CreateUploadResponse>>;

}