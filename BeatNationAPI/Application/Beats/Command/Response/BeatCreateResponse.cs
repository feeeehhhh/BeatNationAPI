using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Beats.Command.Response
{
    public class BeatCreateResponse
    {
        public Guid Id { get; set; }
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
        public DateTime AtualizadoEm { get; set; }
        public List<BeatColab> Colaboradores { get; set; } = new();
<<<<<<< HEAD
        public List<BeatLicencas> BeatLicencas { get; set; } = new();
=======
        public List<BeatLicencaCreateRequest> BeatLicencas { get; set; } = new();
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)


        public static implicit operator BeatCreateResponse(Beat b)
        {
            return new BeatCreateResponse
            {
                Id = b.Id,
                Nome = b.Nome,
                Tags = b.Tags,
                Genero = b.Genero,
                Bpm = b.Bpm,
                ISRC = b.ISRC,
                Escala = b.Escala,
                Tom = b.Tom,
                UrlMp3 = b.UrlMp3,
                UrlWav = b.UrlWav,
                UrlTrackout = b.UrlTrackout,
                UrlCapa = b.UrlCapa,
                CriadoEm = b.CriadoEm,
                AtualizadoEm = b.AtualizadoEm,
                Colaboradores = b.Colaboradores?
                .Select(l => (BeatColab)l)
                .ToList(),
                BeatLicencas = b.BeatLicencas?
<<<<<<< HEAD
                .Select(l => (BeatLicencas)l)
                .ToList()
=======
                .Select(l => new BeatLicencaCreateRequest
                {
                    LicencaId = l.LicencaId,
                    Preco = l.Preco,
                    BeatId = l.BeatId
                })
                .ToList()

>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
            };
        }
    }
};