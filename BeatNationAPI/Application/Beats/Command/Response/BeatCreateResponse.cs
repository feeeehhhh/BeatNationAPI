namespace BeatNationAPI.Application.Beats.Command.Response
{
    public class BeatCreateResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Bpm { get; set; }
        public string ISRC { get; set; } = string.Empty;
        public string Escala { get; set; } = string.Empty;
        public string Tom { get; set; } = string.Empty;
        public string UrlMP3 { get; set; } = string.Empty;
        public string UrlWAV { get; set; } = string.Empty;
        public string UrlTRACKOUT { get; set; } = string.Empty;
        public string UrlCAPA { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}