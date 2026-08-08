using System.Threading.Tasks;
using src.features.Beats.Command.Request;
using src.features.Beats.Command.Response;
using src.Data;
using src.features.Interface.Beats.Command;
using src.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace src.features.Handlers
{
    // Corrija a assinatura da classe para implementar IRequestHandler<BeatCreateRequest, BeatCreateResponse>
    public class BeatCreateHandler : IRequestHandler<BeatCreateRequest, BeatCreateResponse>
    {
        private readonly IBeatRepository _beatRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BeatCreateHandler(IBeatRepository beatRepository, IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _beatRepository = beatRepository;
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BeatCreateResponse> Handle(BeatCreateRequest request, CancellationToken cancellationToken)
        {


            string? mp3FileName = null;
            string? wavFileName = null;
            string? trackoutFileName = null;
            string? coverFileName = null;

            // var currentUserIdString = _httpContextAccessor.HttpContext.User
            // .FindFirst("id")?.Value; ;
            // // faz a conversão do string para Guid
            // if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            // {
            //     throw new UnauthorizedAccessException("Token inválido ou ausente");
            // }

            var uploadsPath = @"D:\BeatNAtion\beats"; // Substituir pelo de baixo após subir prod
            // var uploadsPath = Path.Combine(
            //     _environment.ContentRootPath,
            //     "uploads",
            //     "beats");

            if(request.FileMp3 != null)
            {
                mp3FileName =  $"{Guid.NewGuid()}{Path.GetExtension(request.FileMp3.FileName)}";
                var mp3Path = Path.Combine(uploadsPath, mp3FileName);

                await using (var stream = new FileStream(mp3Path, FileMode.Create))
                await request.FileMp3.CopyToAsync(stream, cancellationToken);
            }
           
           if(request.FileWav != null)
            {
                wavFileName =  $"{Guid.NewGuid()}{Path.GetExtension(request.FileWav.FileName)}";
                var wavPath = Path.Combine(uploadsPath, wavFileName);

                await using (var stream = new FileStream(wavPath, FileMode.Create))
                await request.FileWav.CopyToAsync(stream, cancellationToken);
            }

            if(request.FileTrackout != null)
            {
                trackoutFileName =  $"{Guid.NewGuid()}{Path.GetExtension(request.FileTrackout.FileName)}";
                var trackoutPath = Path.Combine(uploadsPath, trackoutFileName);

                await using (var stream = new FileStream(trackoutPath, FileMode.Create))
                await request.FileTrackout.CopyToAsync(stream, cancellationToken);
            }

            if(request.FileCover != null)
            {
                coverFileName =  $"{Guid.NewGuid()}{Path.GetExtension(request.FileCover.FileName)}";
                var coverPath = Path.Combine(uploadsPath, coverFileName);

                await using (var stream = new FileStream(coverPath, FileMode.Create))
                await request.FileCover.CopyToAsync(stream, cancellationToken);
            }

            var beat = new Beat
            {
                Id = Guid.NewGuid(),
                ProducerId = request.ProducerId,
                Name = request.Name,
                Tags = request.Tags,
                Genre = request.Genre,
                Bpm = request.Bpm,
                ISRC = request.ISRC,
                Scale = request.Scale,
                Tone = request.Tone,
                UrlMp3 = mp3FileName != null ? $"uploads/beats/{mp3FileName}" : null,
                UrlWav = wavFileName != null ? $"uploads/beats/{wavFileName}" : null,
                UrlTrackout = trackoutFileName != null ? $"uploads/beats/{trackoutFileName}" : null,
                UrlCover = coverFileName != null ? $"uploads/beats/{coverFileName}" : null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };

            await _beatRepository.CreateAsync(beat);

            return beat;


        }

    }

}
