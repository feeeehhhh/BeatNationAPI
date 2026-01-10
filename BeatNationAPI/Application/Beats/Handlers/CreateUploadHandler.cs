using System.Text;
using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Common.Responses;
using MediatR;

namespace BeatNationAPI.Application.Beats.Handlers
{
    public class CreateUploadHandler : IRequestHandler<CreateUploadRequest, Response<CreateUploadResponse>>
    {
        private readonly IConfiguration _config;
        public CreateUploadHandler(IConfiguration config)
        {
            _config = config;
        }
        public Task<Response<CreateUploadResponse>> Handle(CreateUploadRequest request, CancellationToken cancellationToken)
        {
            var accountId = _config["Cloudflare:AccountId"];
            var accessKey = _config["Cloudflare:AccessKeyId"];
            var secretKey = _config["Cloudflare:SecretAccessKey"];
            var bucket = _config["Cloudflare:Bucket"];
            var publicDomain = _config["Cloudflare:PublicDomain"];

            // Nome único
            var objectKey = $"uploads/{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}-{request.UrlFile}";


            // URL para upload
            var uploadUrl =
                $"https://{accountId}.r2.cloudflarestorage.com/{bucket}/{objectKey}";

            // Authorization (Command pattern - Basic Auth)
            var credentials = $"{accessKey}:{secretKey}";
            var authorization = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

            var headers = new Dictionary<string, string>
        {
            { "Authorization", $"Basic {authorization}" }
        };
            var publicUrl = $"{publicDomain}/{objectKey}";

            return Task.FromResult(
                Response<CreateUploadResponse>.Ok(
                    new CreateUploadResponse(uploadUrl, headers, publicUrl)
                )
            );

        }
    }
}