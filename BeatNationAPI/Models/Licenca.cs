using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.Models
{
    public class Licenca
    {
        public int Id { get; set; }

        [Required]
        public decimal Preco { get; set; }
        public decimal Porcentagem { get; set; }
        public string NomeLicencas { get; set; }
        public string Distribuicao { get; set; }
        public string StreamingAudio { get; set; }
        public string StreamingVideo { get; set; }
        public string Video { get; set; }
        public string ApresenFimLucrativos { get; set; }
        public int RoyaltShare { get; set; }
        public string ApresenSemFinsLucrativos { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }

    }
}
