

using BeatNationAPI.Models;

namespace BeatNationAPI.DTOs.Licencas
{
    public class LicencaPresetCreateDto 
    {
        public int PresetId { get; set; }   // Id único do preset
        public string NomePreset { get; set; } = string.Empty;
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

        public static implicit operator LicencaPresets(LicencaPresetCreateDto dto)
        {
            return new LicencaPresets
            {
                PresetId = dto.PresetId,
                NomePreset = dto.NomePreset,
                Porcentagem = dto.Porcentagem,
                NomeLicencas = dto.NomeLicencas,
                Distribuicao = dto.Distribuicao,
                StreamingAudio = dto.StreamingAudio,
                StreamingVideo = dto.StreamingVideo,
                Video = dto.Video,
                RoyaltShare = dto.RoyaltShare,
                ApresenFimLucrativos = dto.ApresenFimLucrativos,
                ApresenSemFinsLucrativos = dto.ApresenSemFinsLucrativos,
                ExibirEmissoraRadio = dto.ExibirEmissoraRadio,
                ExibirEmissoraTV = dto.ExibirEmissoraTV,
            };
        }

    }
}
