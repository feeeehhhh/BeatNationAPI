using System.Threading.Tasks;
using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace BeatNationAPI.Application.Handlers
{
    // Corrija a assinatura da classe para implementar IRequestHandler<BeatCreateRequest, BeatCreateResponse>
    public class BeatCreateHandler : IRequestHandler<BeatCreateRequest, BeatCreateResponse>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BeatCreateHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BeatCreateResponse> Handle(BeatCreateRequest request, CancellationToken cancellationToken)
        {



            // Verifica se o beat já existe
            var isAlready = await _context.Beats
            .FirstOrDefaultAsync(b => b.Name == request.Name
                                    || b.ISRC == request.ISRC);
            if (isAlready != null)
            {
                if (isAlready.Name == request.Name)
                {
                    throw new InvalidOperationException("Já existe um Beat cadastrado com esse nome !");
                }
                if (isAlready.ISRC == request.ISRC)
                {
                    throw new InvalidOperationException("Já existe um Beat cadastrado com esse ISRC !");
                }
            }


            // // Pega o id do IdUsuario via Token
            // var currentUserIdString = _httpContextAccessor.HttpContext.User
            // .FindFirst("id")?.Value; ;
            // // faz a conversão do string para Guid
            // if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            // {
            //     throw new UnauthorizedAccessException("Token inválido ou ausente");
            // }
            //setar no request


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
                UrlMp3 = request.UrlMp3,
                UrlWav = request.UrlWav,
                UrlTrackout = request.UrlTrackout,
                UrlCover = request.UrlCover,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            
            await _context.AddAsync(beat);
            await _context.SaveChangesAsync();

            return beat;


        }

    }

}
