using BeatNationAPI.DTOs.Licencas;
using BeatNationAPI.Models;

namespace BeatNationAPI.DTOs.Beats
    {
        public class BeatReadDto
        {
            public int Id { get; set; }
            public Guid IdUsuario { get; set; }
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
            
            public DateTime CriadoEM { get; set; }
            public DateTime AtualizadoEM { get; set; }

            // Licenças associadas ao beat
            public ICollection<BeatLicencaReadDto> Licencas { get; set; } = new List<BeatLicencaReadDto>();
        public ICollection<BeatColabReadDto> Colaboradores { get; set; } = new List<BeatColabReadDto>();

        public static implicit operator BeatReadDto(Beat entity)
        {
            return new BeatReadDto
            {
                Id = entity.Id,
                IdUsuario = entity.IdUsuario,
                Nome = entity.Nome,
                Tags = entity.Tags,
                Genero = entity.Genero,
                Bpm = entity.Bpm,
                ISRC = entity.ISRC,
                Escala = entity.Escala,
                Tom = entity.Tom,
                UrlMP3 = entity.UrlMP3,
                UrlWAV = entity.UrlWAV,
                UrlTRACKOUT = entity.UrlTRACKOUT,
                UrlCAPA = entity.UrlCAPA,
                CriadoEM = entity.CriadoEM,
                AtualizadoEM = entity.AtualizadoEM,

                Colaboradores = entity.Colaboradores?
                .Select(c => (BeatColabReadDto)c)
                .ToList() ?? new List<BeatColabReadDto>(),


            };
            }

        }
    }


