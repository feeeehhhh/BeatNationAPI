namespace BeatNationAPI.DTOs.Licencas
{
    public class LicencaPresetReadDto
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


        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

    }
}
