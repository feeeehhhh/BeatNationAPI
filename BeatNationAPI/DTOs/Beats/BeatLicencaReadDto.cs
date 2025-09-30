using BeatNationAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.DTOs.Beats
{
    public class BeatLicencaReadDto
    {
        public int Id { get; set; }     
        public decimal Preco { get; set; } 
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

        public static implicit operator BeatLicencaReadDto(BeatLicencas entity)
        {
            return new BeatLicencaReadDto
            {
                Id = entity.Id,
                Preco = entity.Preco,
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
