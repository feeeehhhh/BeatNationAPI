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


            // // Pega o id do IdUsuario via Token
            // var currentUserIdString = _httpContextAccessor.HttpContext.User
            // .FindFirst("id")?.Value; ;
            // // faz a conversão do string para Guid
            // if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            // {
            //     throw new UnauthorizedAccessException("Token inválido ou ausente");
            // }
            //setar no request

            // --- Verifica duplicidade de Nome ou ISRC ---
            var existingBeat = await _context.Beats
                .FirstOrDefaultAsync(b => b.Nome == request.Nome || b.ISRC == request.ISRC, cancellationToken);

            if (existingBeat != null)
            {
                if (existingBeat.Nome == request.Nome)
                    throw new InvalidOperationException("Já existe um Beat cadastrado com esse nome!");

                if (existingBeat.ISRC == request.ISRC)
                    throw new InvalidOperationException("Já existe um Beat cadastrado com esse ISRC!");
            }

            Beat beat = request;
            beat.Id = Guid.NewGuid();
            beat.CriadoEm = DateTime.UtcNow;
            beat.AtualizadoEm = DateTime.UtcNow;

            // --- Cria as licenças relacionadas ---
            var beatLicencas = new List<BeatLicencas>();

            if (request.BeatLicencas != null && request.BeatLicencas.Any())
            {
                foreach (var licencaReq in request.BeatLicencas)
                {
                    var licenca = await _context.Licencas
                        .FirstOrDefaultAsync(l => l.Id == licencaReq.LicencaId, cancellationToken);

                    if (licenca == null)
                    {
                        throw new InvalidOperationException("Licença selecionada não existe, tente novamente mais tarde");
                    }


                    var beatLicenca = new BeatLicencas
                    {
                        Id = Guid.NewGuid(),
                        BeatId = beat.Id,
                        LicencaId = licenca.Id
                    };

                    beatLicencas.Add(beatLicenca);
                }
            }
            beat.BeatLicencas = beatLicencas;
            var beatColabs = request.Colaboradores.Select(c => new BeatColab
            {
                BeatId = beat.Id, // <-- aqui é o Id do beat que acabou de ser salvo
                IdUsuario = c.IdUsuario,
                Participacao = c.Participacao
            }).ToList();

            await _context.BeatColabs.AddRangeAsync(beatColabs);
            await _context.BeatLicencas.AddRangeAsync(beatLicencas);
            await _context.AddAsync(beat);
            await _context.SaveChangesAsync();

            return beat;


        }

    }

}
