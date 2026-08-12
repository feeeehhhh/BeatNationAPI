using src.application.Beats.Command.Response;

using MediatR;

namespace src.application.Beats.Command.Request
{
    public record CreateUploadRequest(string UrlFile) : IRequest<CreateUploadResponse>;

}