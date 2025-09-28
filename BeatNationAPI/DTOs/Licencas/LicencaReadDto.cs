using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.DTOs.Licencas
{

    // Esta é as licenças padrões do sistema, então vai ser so disponiblizado pra leitura no front end ,pois não é editavel
    public class LicencaDto
    {
        public int Id { get; set; }

        public decimal Porcentagem { get; set; } 
        public string NomeLicencas { get; set; } = string.Empty;
        public string Distribuicao { get; set; } = string.Empty;
        public string StreamingAudio { get; set; } = string.Empty;
        public string StreamingVideo { get; set; } = string.Empty;
        public string Video { get; set; } = string.Empty;
        public string ApresenFimLucrativos { get; set; } = string.Empty;
        public int RoyaltShare { get; set; }
        public string ApresenSemFinsLucrativos { get; set; } = string.Empty;
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }

    }
}
