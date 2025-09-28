using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.Models
{
    public class Beat
    {
        public int Id { get; set; }
        public Guid IdUsuario { get; set; }  // ID do colaborador/produtor

        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;
        public string? Tags { get; set; } = string.Empty;

        [Required]
        public string Genero { get; set; } = string.Empty;

        [Required]
        public int Bpm { get; set; } 
        public string? ISRC { get; set; } = string.Empty;
        public string? Escala { get; set; } = string.Empty;
        public string? Tom { get; set; } = string.Empty;
        public string UrlMP3 { get; set; } = string.Empty;
        public string UrlWAV { get; set; } = string.Empty;
        public string UrlTRACKOUT { get; set; } = string.Empty;
        public string UrlCAPA { get; set; } = string.Empty;

        public DateTime CriadoEM { get; set; }
        public DateTime AtualizadoEM { get; set ; }

        public ICollection<License> Licenses { get; set; } = new List<License>();

    }
}
