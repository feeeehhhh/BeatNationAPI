using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public class BeatLicencaCreateRequest : IRequest<BeatCreateResponse>
    {
        public Guid Id { get; set; }

        // Relacionamento com Beat
        public Guid BeatId { get; set; }
        public Beat? Beat { get; set; } // agora pode ser nul
        public int LicencaId { get; set; }
        public Guid PresetLicencaId { get; set; }
        public PresetLicenca PresetLicenca { get; set; }

        public Guid LicencaBaseId { get; set; }
        public LicencaBase Licencas { get; set; }

        // Configurações do preset
        public int PeriodoUso { get; set; }
        public int Distribuicao { get; set; }
        public int StreamingAudio { get; set; }
        public int StreamingVideo { get; set; }
        public int Video { get; set; }
        public int ApresenSemFinsLucrativos { get; set; }
        public int ApresenFimLucrativos { get; set; }
        public int Preco { get; set; }
        public int Porcentagem { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }


        public static implicit operator BeatLicencas(BeatLicencaCreateRequest b)
        {
            return new BeatLicencas
            {
                Id = b.Id,
                Preco = b.Preco,
                BeatId = b.BeatId,
                Beat = b.Beat,
                PresetLicencaId = b.PresetLicencaId,

            };
        }
    }
}