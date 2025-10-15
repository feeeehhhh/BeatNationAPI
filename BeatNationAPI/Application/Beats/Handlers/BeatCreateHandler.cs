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
            .FirstOrDefaultAsync(b => b.Nome == request.Nome
                                    || b.ISRC == request.ISRC);
            if (isAlready != null)
            {
                if (isAlready.Nome == request.Nome)
                {
                    throw new InvalidOperationException("Já existe um Beat cadastrado com esse nome !");
                }
                if (isAlready.ISRC == request.ISRC)
                {
                    throw new InvalidOperationException("Já existe um Beat cadastrado com esse ISRC !");
                }
            }


            // Pega o id do IdUsuario via Token
            var currentUserIdString = _httpContextAccessor.HttpContext.User
            .FindFirst("id")?.Value; ;
            // faz a conversão do string para Guid
            if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente");
            }
            //setar no request
            request.OwnerId = currentUserId;
            Beat beat = request;
            beat.Id = Guid.NewGuid();
            beat.CriadoEm = DateTime.UtcNow;
            beat.AtualizadoEm = DateTime.UtcNow;

            // Faz a criação das licencas relacionadas ao beat
            var beatLicencasGeradas = new List<BeatLicencas>();
            foreach (var licenca in beat.BeatLicencas)
            {
                if (licenca.PresetLicencaId != Guid.Empty)
                {
                    var preset = await _context.PresetLicencas
                        .Include(p => p.Licencas)
                        .FirstOrDefaultAsync(p => p.Id == licenca.PresetLicencaId);

                    if (preset != null)
                    {
                        var beatLicencas = preset.Licencas
                        .Select(config => new BeatLicencaCreateRequest
                        {
                            Id = Guid.NewGuid(),
                            BeatId = beat.Id,
                            PresetLicencaId = preset.Id,
                            Preco = config.Preco,
                            PeriodoUso = config.PeriodoUso,
                            Distribuicao = config.Distribuicao,
                            StreamingAudio = config.StreamingAudio,
                            StreamingVideo = config.StreamingVideo,
                            Video = config.Video,
                            ApresenSemFinsLucrativos = config.ApresenSemFinsLucrativos,
                            ApresenFimLucrativos = config.ApresenFimLucrativos,
                            Porcentagem = config.Porcentagem,
                            RoyaltShare = config.RoyaltShare,
                            ExibirEmissoraRadio = config.ExibirEmissoraRadio,
                            ExibirEmissoraTV = config.ExibirEmissoraTV
                        }).ToList();

                        beat.BeatLicencas.AddRange((IEnumerable<BeatLicencas>)beatLicencas);
                    }
                    else
                    {
                        preset = await _context.PresetLicencas
                        .Include(p => p.Licencas)
                        .FirstOrDefaultAsync(p => p.Id == Guid.Parse("97806a3e-ea4d-4c0f-a82f-664f9016990f"));
                    }
                }
            }
            beat.BeatLicencas = beatLicencasGeradas;

            var beatColabs = request.Colaboradores.Select(c => new BeatColab
            {
                BeatId = beat.Id, // <-- aqui é o Id do beat que acabou de ser salvo
                IdUsuario = c.IdUsuario,
                Participacao = c.Participacao
            }).ToList();

            await _context.BeatColabs.AddRangeAsync(beatColabs);
            await _context.BeatLicencas.AddRangeAsync(beatLicencasGeradas);
            await _context.AddAsync(beat);
            await _context.SaveChangesAsync();

            return beat;


        }



    }

}