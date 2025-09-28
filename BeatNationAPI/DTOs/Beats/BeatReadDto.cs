namespace BeatNationAPI.DTOs.Beats
    {
        public class BeatReadDto
        {
            public Guid Id { get; set; }
            public Guid ProdutorId { get; set; }
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
            public decimal Preco { get; set; }
            public DateTime CriadoEM { get; set; }
            public DateTime AtualizadoEM { get; set; }

            // Licenças associadas ao beat
            public ICollection<BeatLicencaReadDto> Licenses { get; set; } = new List<BeatLicencaReadDto>();
        }
    }


