
using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Licencas.Handlers
{
    public class LicencaUpdateHandler : IRequestHandler<LicencaUpdateRequest, Guid>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LicencaUpdateHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> Handle(LicencaUpdateRequest request, CancellationToken cancellationToken)
        {

            // Pega o id do IdUsuario via Token
            var currentUserIdString = _httpContextAccessor.HttpContext.User
            .FindFirst("id")?.Value; ;
            // faz a conversão do string para Guid
            if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente");
            }


            var licenca = await _context.Licencas
            .Include(l => l.LicencaConfig)
            .FirstOrDefaultAsync(l => l.Id == request.Id &&  l.OwnerId == currentUserId, cancellationToken);

            if (licenca == null)
            {
                throw new KeyNotFoundException("Não foi possível atulizar a liceça.");
            }

            licenca.Nome = request.Nome ?? licenca.Nome;
            licenca.Descricao = request.Descricao ?? licenca.Descricao;
            licenca.Categoria = request.Categoria ?? licenca.Categoria;

            if (request.LicencaConfig != null)
            {
                foreach (var configAtualizada in request.LicencaConfig)
                {
                    var configExistente = licenca.LicencaConfig
                        .FirstOrDefault(c => c.Id == configAtualizada.Id);
                    if (configExistente != null)
                    {
                        configExistente.PeriodoUso = configAtualizada.PeriodoUso;
                        configExistente.Distribuicao = configAtualizada.Distribuicao;
                        configExistente.StreamingAudio = configAtualizada.StreamingAudio;
                        configExistente.StreamingVideo = configAtualizada.StreamingVideo;
                        configExistente.Video = configAtualizada.Video;
                        configExistente.ApresenSemFinsLucrativos = configAtualizada.ApresenSemFinsLucrativos;
                        configExistente.ApresenFimLucrativos = configAtualizada.ApresenFimLucrativos;
                        configExistente.Preco = configAtualizada.Preco;
                        configExistente.Porcentagem = configAtualizada.Porcentagem;
                        configExistente.RoyaltShare = configAtualizada.RoyaltShare;
                        configExistente.ExibirEmissoraRadio = configAtualizada.ExibirEmissoraRadio;
                        configExistente.ExibirEmissoraTV = configAtualizada.ExibirEmissoraTV;

                    }
                }
            }
            await _context.SaveChangesAsync(cancellationToken);
            return licenca.Id;
        }

    }
}