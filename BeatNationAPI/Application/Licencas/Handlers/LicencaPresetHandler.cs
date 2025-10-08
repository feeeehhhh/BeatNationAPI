
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

            //Cria as Licencas Padrões

            var licencaBasica = new LicencaBase
            {
                Id = Guid.Parse("1"),
                Nome = "Básica",

            };

            var licencaVIP = new LicencaBase
            {
                Id = Guid.Parse("2"),
                Nome = "VIP",

            };

            var licencaExclusiva = new LicencaBase
            {
                Id = Guid.Parse("3"),
                Nome = "Exclusiva",
            };

            // Adiciona no banco
            _context.LicencasBase.AddRange(licencaBasica, licencaVIP, licencaExclusiva);
            await _context.SaveChangesAsync(cancellationToken);


            // Cria o preset Default
            var presetDefault = new PresetLicenca
            {
                Id = Guid.Parse("97806a3e-ea4d-4c0f-a82f-664f9016990f"),
                Nome = "Default",
                Descricao = "Preset inicial com as 3 licenças padrão",
                Licencas = new List<PresetLicencaConfig>
        {
        new PresetLicencaConfig // Básica
        {
            Id = Guid.NewGuid(),
            LicencaBaseId = Guid.Parse("724c5c55-ecb3-4fc1-a2ad-d77a02833d24"), // ID da Básica
            PeriodoUso = 1,
            Distribuicao = 15000,
            StreamingAudio = 20000,
            StreamingVideo = 20000,
            Video = 1,
            ApresenSemFinsLucrativos = 2500,
            ApresenFimLucrativos = 300,
            Preco = 0,
            Porcentagem = 20,
            RoyaltShare = 20,
            ExibirEmissoraRadio = true,
            ExibirEmissoraTV = false
        },
        new PresetLicencaConfig // VIP
        {
            Id = Guid.NewGuid(),
            LicencaBaseId = Guid.Parse("75974e74-12de-41e4-9fca-f9b87e04e5a6"), // Id da licenca VIP
            PeriodoUso = 3,
            Distribuicao = 20000,
            StreamingAudio = 50000,
            StreamingVideo = 50000,
            Video = 1,
            ApresenSemFinsLucrativos = 5000,
            ApresenFimLucrativos = 500,
            Preco = 0,
            Porcentagem = 30,
            RoyaltShare = 20,
            ExibirEmissoraRadio = true,
            ExibirEmissoraTV = true
        },
        new PresetLicencaConfig // Exclusiva
        {
            Id = Guid.NewGuid(),
            LicencaBaseId = Guid.Parse("ead25d1b-6568-4913-98cd-2f363f235d8b"), //Id da exclusiva
            PeriodoUso = 99999, // Ilimitado
            Distribuicao = 999999,
            StreamingAudio = 999999,
            StreamingVideo = 999999,
            Video = 999999,
            ApresenSemFinsLucrativos = 999999,
            ApresenFimLucrativos = 999999,
            Preco = 0,
            Porcentagem = 100,
            RoyaltShare = 20,
            ExibirEmissoraRadio = true,
            ExibirEmissoraTV = true
        }
    }
            };
            // salva o preset no banco
            _context.PresetLicencas.Add(presetDefault);
            await _context.SaveChangesAsync(cancellationToken);


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
                    LicencaBaseId = l.LicencaBaseId,
                    PeriodoUso = l.PeriodoUsoInt,
                    Distribuicao = l.DistribuicaoInt,
                    StreamingAudio = l.StreamingAudioInt,
                    StreamingVideo = l.StreamingVideoInt,
                    Video = l.VideoInt,
                    ApresenSemFinsLucrativos = l.ApresenSemFinsLucrativosInt,
                    ApresenFimLucrativos = l.ApresenFimLucrativosInt,
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
