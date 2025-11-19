using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Common.Responses;
using MediatR;

namespace BeatNationAPI.Application.Beats.Handlers
{
    public class CreateUploadHandler : IRequestHandler<CreateUploadRequest, Response<CreateUploadResponse>>
    {
    }
}