using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Beats.Command.Response
{
    public class BeatCreatePublicResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Bpm { get; set; }
        public string ISRC { get; set; } = string.Empty;
        public string Escala { get; set; } = string.Empty;
        public string Tom { get; set; } = string.Empty;


        public static implicit operator BeatCreatePublicResponse(Beat b)
        {
            return new BeatCreatePublicResponse
            {
                Id = b.Id,
                Nome = b.Nome,
                Tags = b.Tags,
                Genero = b.Genero,
                Bpm = b.Bpm,
                ISRC = b.ISRC,
                Escala = b.Escala,
                Tom = b.Tom,
            };
        }
    }
    public class BeatCreatePrivateResponse : BeatCreatePublicResponse
    {
        public string UrlMp3 { get; set; } = string.Empty;
        public string UrlWav { get; set; } = string.Empty;
        public string UrlTrackout { get; set; } = string.Empty;
        public string UrlCapa { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public static implicit operator BeatCreatePrivateResponse(Beat b)
        {
            return new BeatCreatePrivateResponse
            {
                UrlMp3 = b.UrlMp3,
                UrlWav = b.UrlWav,
                UrlTrackout = b.UrlTrackout,
                UrlCapa = b.UrlCapa,
                CriadoEm = b.CriadoEm,
                AtualizadoEm = b.AtualizadoEm,
            };
        }
    }
}