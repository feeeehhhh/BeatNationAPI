
<<<<<<< HEAD



using System.Text.Json.Serialization;

=======
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
namespace BeatNationAPI.Models
{
    public class BeatLicencas
    {
<<<<<<< HEAD
        
        public Guid Id { get; set; }

        // Relacionamento com Beat
        public Guid BeatId { get; set; }
        
        [JsonIgnore] // Evita referência circular na serialização JSON
        public Beat? Beat { get; set; } // agora pode ser nulo


        public decimal Preco { get; set; }
        // Relacionamento com Licença
        public Guid LicencaId { get; set; }
        
        [JsonIgnore] // Evita referência circular na serialização JSON
        public Licenca Licencas { get; set; }
    }
}

        
    
=======

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



>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
