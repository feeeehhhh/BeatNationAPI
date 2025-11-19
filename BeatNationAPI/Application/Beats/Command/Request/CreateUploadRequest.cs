using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Common.Responses;
using MediatR;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public record CreateUploadRequest(string UrlFile) : IRequest<Response<CreateUploadResponse>>;

}