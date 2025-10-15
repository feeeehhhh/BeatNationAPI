
using System.Runtime.InteropServices;
using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command
{

    public class PresetCreateHandler :
        IRequestHandler<PresetCreateRequest, PresetCreateResponse>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PresetCreateHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;



        }

        public async Task<PresetCreateResponse> Handle(PresetCreateRequest request, CancellationToken cancellationToken)
        {
            // Pega o id do IdUsuario via Token
            var currentUserIdString = _httpContextAccessor.HttpContext.User
            .FindFirst("id")?.Value; ;
            // faz a conversão do string para Guid
            if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente");
            }

            var preset = new PresetLicenca
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Descricao = request.Descricao,
                OwnerId = currentUserId,
                Licencas = request.Licencas.Select(l => new PresetLicencaConfig
                {
                    Id = Guid.NewGuid(),
                    LicencaId = l.LicencaId,
                    PeriodoUso = l.PeriodoUso,
                    Distribuicao = l.Distribuicao,
                    StreamingAudio = l.StreamingAudio,
                    StreamingVideo = l.StreamingVideo,
                    Video = l.Video,
                    ApresenSemFinsLucrativos = l.ApresenSemFinsLucrativos,
                    ApresenFimLucrativos = l.ApresenFimLucrativos,
                    Preco = l.Preco,
                    Porcentagem = l.Porcentagem,
                    RoyaltShare = l.RoyaltShare,
                    ExibirEmissoraRadio = l.ExibirEmissoraRadio,
                    ExibirEmissoraTV = l.ExibirEmissoraTV

                }).ToList()
            };

            // Salva no banco
            _context.PresetLicencas.Add(preset);
            await _context.SaveChangesAsync(cancellationToken);

            return preset;
        }

    }


}
