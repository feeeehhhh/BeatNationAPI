using MediatR;
using BeatNationAPI.Application.Licencas.Command.Response;
using System.Collections.Generic;
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Command.Licencas.Request
{
    public class PresetLicencaConfigResponse
    {

        public Guid Id { get; set; }
        public Guid LicencaBaseId { get; set; }
        public string LicencaBaseNome { get; set; }
        public int PeriodoUso { get; set; }
        public int Distribuicao { get; set; }
        public int StreamingAudio { get; set; }
        public int StreamingVideo { get; set; }
        public int Video { get; set; }
        public int ApresenSemFinsLucrativos { get; set; }
        public int ApresenFimLucrativos { get; set; }
        public decimal Preco { get; set; }
        public int Porcentagem { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }

        public static implicit operator PresetLicencaConfigResponse(PresetLicencaConfig l)
        {
            return new PresetLicencaConfigResponse
            {
                Id = l.Id,
                LicencaBaseId = l.LicencaBaseId,
                LicencaBaseNome = l.LicencaBaseNome,
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
