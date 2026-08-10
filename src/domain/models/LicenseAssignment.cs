
namespace src.Models
{
    public class LicenseAssignment 
    {
       // Refazer depois esta parte 
        public Guid Id { get; set; }
        public Guid BeatId { get; set; }
        public Beat Beat { get; set; }
        public Guid LicencaId { get; set; }
        public License Licencas { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public ValueOrIlimited PeriodoUso { get; set; }
        public ValueOrIlimited Distribuicao { get; set; }
        public ValueOrIlimited StreamingAudio { get; set; }
        public ValueOrIlimited StreamingVideo { get; set; }
        public ValueOrIlimited Video { get; set; }
        public ValueOrIlimited ApresenSemFinsLucrativos { get; set; }
        public ValueOrIlimited ApresenFimLucrativos { get; set; }

        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }

        public DateTime CriadoEm { get; set; }
        public bool CompartilharMp3 { get; set; } = false;
        public bool CompartilharWav { get; set; } = false;
        public bool CompartilharTrackout { get; set; } = false;
        
        
    }
}



