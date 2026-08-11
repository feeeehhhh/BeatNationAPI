using System.Threading.Tasks;
using src.application.Beats.Command.Request;
using src.application.Beats.Command.Response;
using src.infra.data;
using src.application.Interface.Beats.Command;
using src.domain.models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using src.application.Beats.Command.Validators;
using src.application.Beats.Handlers;

namespace src.application.Handlers
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

            var uploadsPath = @"/mnt/Uploads"; // Substituir pelo de baixo após subir prod
                                               // var uploadsPath = Path.Combine(
                                               //     _environment.ContentRootPath,
                                               //     "uploads",
                                               //     "beats");
                                               //Validações de arquivos
                                               // Pelo menos um arquivo deve ser enviado

            // Validações de arquivos
            if (request.FileMp3 == null &&
                request.FileWav == null &&
                request.FileTrackout == null &&
                request.FileCover == null)
            {
                throw new ArgumentException(
                    "É necessário enviar pelo menos um arquivo."
                );
            }

            if (request.FileMp3 != null)
            {
                if (!FileValidator.validateFileExtension(request.FileMp3, [".mp3"]))
                {
                    throw new ArgumentException(
                        "O arquivo MP3 não é válido."
                    );
                }
                mp3FileName = $"{Guid.NewGuid()}{Path.GetExtension(request.FileMp3.FileName)}";
                var mp3Path = Path.Combine(uploadsPath, mp3FileName);
                await using (var stream = new FileStream(mp3Path, FileMode.Create))
                    await request.FileMp3.CopyToAsync(stream, cancellationToken);
            }

            if (request.FileWav != null)
            {
                if (!FileValidator.validateFileExtension(request.FileWav, [".wav"]))
                {
                    throw new ArgumentException(
                        "O arquivo WAV não é válido."
                    );
                }
                wavFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.FileWav.FileName)}";
                var wavPath = Path.Combine(uploadsPath, wavFileName);
                await using (var stream = new FileStream(wavPath, FileMode.Create))
                    await request.FileWav.CopyToAsync(stream, cancellationToken);
            }

            if (request.FileTrackout != null)
            {
                if (!FileValidator.validateFileExtension(request.FileTrackout, [".zip", ".rar"]))
                {
                    throw new ArgumentException("O arquivo Trackout não é válido. Certifique-se de que o arquivo tenha a extensão .zip ou .rar.");
                }
                trackoutFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.FileTrackout.FileName)}";
                var trackoutPath = Path.Combine(uploadsPath, trackoutFileName);
                await using (var stream = new FileStream(trackoutPath, FileMode.Create))
                    await request.FileTrackout.CopyToAsync(stream, cancellationToken);
            }

            if (request.FileCover != null)
            {
                if (!FileValidator.validateFileExtension(request.FileCover, [".jpg", ".png"]))
                {
                    throw new ArgumentException("O arquivo de capa não é válido. Certifique-se de que o arquivo tenha a extensão .jpg ou .png.");
                }
                coverFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.FileCover.FileName)}";
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
