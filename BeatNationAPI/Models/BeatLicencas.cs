
namespace BeatNationAPI.Models
{
    public class BeatLicencas
    {

        public Guid Id { get; set; }
        public Guid BeatId { get; set; }
        public Beat Beat { get; set; }
        public Guid LicencaId { get; set; }
        public Licenca Licencas { get; set; }
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

        public DateTime CriadoEm { get; set; }
        public bool CompartilharMp3 { get; set; } = false;
        public bool CompartilharWav { get; set; } = false;
        public bool CompartilharTrackout { get; set; } = false;
        
        
    }
}



