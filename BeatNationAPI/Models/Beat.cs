

namespace BeatNationAPI.Models
{
    public class Beat
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }  // ID do colaborador/produtor
        public string Nome { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
<<<<<<< HEAD
        public int Bpm { get; set; } 
=======
        public int? Bpm { get; set; } 
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
        public string ISRC { get; set; } = string.Empty;
        public string Escala { get; set; } = string.Empty;
        public string Tom { get; set; } = string.Empty;
        public string UrlMp3 { get; set; } = string.Empty;
        public string UrlWav { get; set; } = string.Empty;
        public string UrlTrackout { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set ; }

        public ICollection<BeatLicencas> BeatLicencas { get; set; } = new List<BeatLicencas>();
        public ICollection<BeatColab> Colaboradores { get; set; } = new List<BeatColab>();

    }
}
