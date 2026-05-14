

namespace BeatNationAPI.Models
{
    public class Beat
    {
        public Guid Id { get; set; }
        public Guid ProducerId { get; set; }  // ID do colaborador/
        public string Name { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int? Bpm { get; set; } 
        public string ISRC { get; set; } = string.Empty;
        public string Scale { get; set; } = string.Empty;
        public string Tone { get; set; } = string.Empty;
        public string UrlMp3 { get; set; } = string.Empty;
        public string UrlWav { get; set; } = string.Empty;
        public string UrlTrackout { get; set; } = string.Empty;
        public string UrlCover { get; set; } = string.Empty;

        public DateTime CreatedAt{ get; set; }
        public DateTime UpdatedAt { get; set ; }
       // public ICollection<BeatLicencas> LicenseAssingnment { get; set; } = new List<BeatLicencas>();

    }
}
