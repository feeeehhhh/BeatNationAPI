using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public class BeatCreateRequest : IRequest<BeatCreateResponse>
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
=======
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
        public Guid OwnerId { get; set; }  // ID pegado via token
        public Guid LicencaId { get; set; } // Licença Padrão
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

<<<<<<< HEAD
        public List<BeatColabCreateRequest>Colaboradores { get; set; } = new();
        public List<BeatLicencaCreateRequest>BeatLicencas { get; set; } = new();
=======
        public List<BeatColabCreateRequest> Colaboradores { get; set; } = new();
        public List<BeatLicencaCreateRequest> BeatLicencas { get; set; } = new();
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)

        public static implicit operator Beat(BeatCreateRequest b)
        {
            return new Beat
            {
<<<<<<< HEAD
                Id = b.Id,
=======
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
                OwnerId = b.OwnerId,
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
                Colaboradores = b.Colaboradores?
<<<<<<< HEAD
                .Select(l =>new BeatColab
                {
                    IdUsuario = l.IdUsuario,
=======
                .Select(l => new BeatColab
                {
                    Username = l.Username,
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
                    Participacao = l.Participacao
                })
                .ToList(),
                BeatLicencas = b.BeatLicencas?
                .Select(l => new BeatLicencas
<<<<<<< HEAD
                {   
                    Id = l.Id,
                    LicencaId = l.LicencaId
                })
                .ToList()
                
=======
                {

                    LicencaId = l.LicencaId,
                    BeatId = l.BeatId,
                    Preco = l.Preco
                })
                .ToList()

>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)

            };
        }

    }
}