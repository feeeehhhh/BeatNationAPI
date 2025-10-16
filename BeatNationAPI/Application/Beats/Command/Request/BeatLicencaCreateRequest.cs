using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public class BeatLicencaCreateRequest
    {
        public Guid Id { get; set; }
        public Guid BeatId { get; set; }
        public Guid LicencaId { get; set; }
        public int Preco { get; set; }
        public required ValorOuIlimitado PeriodoUso { get; set; }
        public required ValorOuIlimitado Distribuicao { get; set; }
        public required ValorOuIlimitado StreamingAudio { get; set; }
        public required ValorOuIlimitado StreamingVideo { get; set; }
        public required ValorOuIlimitado Video { get; set; }
        public required ValorOuIlimitado ApresenSemFinsLucrativos { get; set; }
        public required ValorOuIlimitado ApresenFimLucrativos { get; set; }
        public int Porcentagem { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }
    }
}