using BeatNationAPI.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.DTOs.Beats
{
    public class BeatCreateDto
    {


        public Guid IdUsuario { get; set; }  // ID pegado via token

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

        // Colaboradores associados ao beat
        public ICollection<BeatColabCreateDto> Colaboradores { get; set; } = new List<BeatColabCreateDto>();
        public ICollection<LicencaPresets> Licenses { get; set; } = new List<LicencaPresets>();

    }
}
