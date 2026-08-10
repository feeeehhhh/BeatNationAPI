using src.features.Beats.Command.Response;

using MediatR;

namespace src.features.Beats.Command.Request
{
    public record CreateUploadRequest(string UrlFile) : IRequest<CreateUploadResponse>;

}