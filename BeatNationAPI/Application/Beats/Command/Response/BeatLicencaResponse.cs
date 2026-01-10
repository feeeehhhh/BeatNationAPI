using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Beats.Command.Response
{
    public class BeatLicencaResponse
    {
        public Guid Id { get; set; }
        public Guid BeatId { get; set; }
        public Guid LicencaId { get; set; }
        public decimal Preco { get; set; }

        public string Nome { get; set; } = string.Empty;
        public ValorOuIlimitado PeriodoUso { get; set; }
        public ValorOuIlimitado Distribuicao { get; set; }
        public ValorOuIlimitado StreamingAudio { get; set; }
        public ValorOuIlimitado StreamingVideo { get; set; }
        public ValorOuIlimitado Video { get; set; }
        public ValorOuIlimitado ApresenSemFinsLucrativos { get; set; }
        public ValorOuIlimitado ApresenFimLucrativos { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }

        public static implicit operator BeatLicencaResponse(BeatLicencas bl)
        {
            return new BeatLicencaResponse
            {
                Id = bl.Id,
                BeatId = bl.BeatId,
                LicencaId = bl.LicencaId,
                Preco = bl.Preco,
                Nome = bl.Nome,
                PeriodoUso = bl.PeriodoUso,
                Distribuicao = bl.Distribuicao,
                StreamingAudio = bl.StreamingAudio,
                StreamingVideo = bl.StreamingVideo,
                Video = bl.Video,
                ApresenSemFinsLucrativos = bl.ApresenSemFinsLucrativos,
                ApresenFimLucrativos = bl.ApresenFimLucrativos,
                RoyaltShare = bl.RoyaltShare,
                ExibirEmissoraRadio = bl.ExibirEmissoraRadio,
                ExibirEmissoraTV = bl.ExibirEmissoraTV
            };
        }


    }
}