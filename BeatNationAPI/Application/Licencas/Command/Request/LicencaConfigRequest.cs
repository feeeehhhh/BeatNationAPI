using System.Text.Json.Serialization;
using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command.Request
{
    public class LicencaConfigCreateRequest : IRequest<LicencaCreateResponse>
    {
        public Guid Id { get; set; }
        public Guid LicencaId { get; set; }

        [JsonIgnore]
        public Licenca? Licenca { get; set; }
        public required ValorOuIlimitado PeriodoUso { get; set; }
        public required ValorOuIlimitado Distribuicao { get; set; }
        public required ValorOuIlimitado StreamingAudio { get; set; }
        public required ValorOuIlimitado StreamingVideo { get; set; }
        public required ValorOuIlimitado Video { get; set; }
        public required ValorOuIlimitado ApresenSemFinsLucrativos { get; set; }
        public required ValorOuIlimitado ApresenFimLucrativos { get; set; }
        public int Preco { get; set; }
        public int Porcentagem { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }
        
        public static implicit operator LicencaConfig(LicencaConfigCreateRequest l)
        {
            return new LicencaConfig
            {
                Id = l.Id,
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
            };
        }
    }

}


