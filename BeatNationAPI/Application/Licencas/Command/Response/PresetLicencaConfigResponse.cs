using MediatR;
using BeatNationAPI.Application.Licencas.Command.Response;
using System.Collections.Generic;
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Command.Licencas.Request
{
    public class PresetLicencaConfigResponse
    {

        public Guid Id { get; set; }
        public Guid LicencasId { get; set; }
        public string LicencaNome { get; set; }
        // Configurações do preset
        
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

        public static implicit operator PresetLicencaConfigResponse(PresetLicencaConfig l)
        {
            return new PresetLicencaConfigResponse
            {
                Id = l.Id,
                LicencasId = l.LicencasId,
                LicencaNome = l.LicencaNome,
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
