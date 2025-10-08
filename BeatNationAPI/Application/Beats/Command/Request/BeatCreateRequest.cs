using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public class BeatCreateRequest : IRequest<BeatCreateResponse>
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }  // ID pegado via token
        public string Nome { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Bpm { get; set; }
        public string ISRC { get; set; } = string.Empty;
        public string Escala { get; set; } = string.Empty;
        public string Tom { get; set; } = string.Empty;
        public string UrlMp3 { get; set; } = string.Empty;
        public string UrlWav { get; set; } = string.Empty;
        public string UrlTrackout { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;

        public List<BeatColabCreateRequest>Colaboradores { get; set; } = new();
        public List<BeatLicencaCreateRequest>BeatLicencas { get; set; } = new();

        public static implicit operator Beat(BeatCreateRequest b)
        {
            return new Beat
            {
                Id = b.Id,
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
                .Select(l =>new BeatColab
                {
                    IdUsuario = l.IdUsuario,
                    Participacao = l.Participacao
                })
                .ToList(),
                BeatLicencas = b.BeatLicencas?
                .Select(l => new BeatLicencas
                {   
                    Id = l.Id,
                    PresetLicencaId = l.PresetLicencaId
                })
                .ToList()

            };
        }

    }
}