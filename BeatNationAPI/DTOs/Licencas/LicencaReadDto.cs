using BeatNationAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.DTOs.Licencas
{

    // Esta é as licenças padrões do sistema, então vai ser so disponiblizado pra leitura no front end ,pois não é editavel
    public class LicencaReadDto
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

        public static implicit operator LicencaReadDto(Licenca entity)
        {
            return new LicencaReadDto
            {

                Id = entity.Id,
                Porcentagem = entity.Porcentagem,
                NomeLicencas = entity.NomeLicencas,
                Distribuicao = entity.Distribuicao,
                StreamingAudio = entity.StreamingAudio,
                StreamingVideo = entity.StreamingVideo,
                Video = entity.Video,
                ApresenFimLucrativos = entity.ApresenFimLucrativos,
                ApresenSemFinsLucrativos = entity.ApresenSemFinsLucrativos,
                ExibirEmissoraRadio = entity.ExibirEmissoraRadio,
                ExibirEmissoraTV = entity.ExibirEmissoraTV,

            };
        }
    }
}
