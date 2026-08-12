using src.application.Beats.Command.Response;
using src.domain.models;
using MediatR;

namespace src.application.Beats.Command.Request
{
    public class BeatCreateRequest : IRequest<BeatCreateResponse>
    {
        public Guid Id { get; set; }
        public Guid ProducerId { get; set; }  // ID pegado via token
        public string Name { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int? Bpm { get; set; }
        public string ISRC { get; set; } = string.Empty;
        public string Scale { get; set; } = string.Empty;
        public string Tone { get; set; } = string.Empty;
        public IFormFile? FileMp3 { get; set; } = null;
        public string UrlMp3 { get; set; } = string.Empty;
        public IFormFile? FileWav { get; set; }
        public string UrlWav { get; set; } = string.Empty;
        public IFormFile? FileTrackout { get; set; } 
        public string UrlTrackout { get; set; } = string.Empty;
        public IFormFile? FileCover { get; set; } 
        public string UrlCover { get; set; } = string.Empty;


        public static implicit operator Beat(BeatCreateRequest b)
        {
            return new Beat
            {
                Id = b.Id,
                ProducerId = b.ProducerId,
                Name = b.Name,
                Tags = b.Tags,
                Genre = b.Genre,
                Bpm = b.Bpm,
                ISRC = b.ISRC,
                Scale = b.Scale,
                Tone = b.Tone,
                UrlMp3 = b.UrlMp3,
                UrlWav = b.UrlWav,
                UrlTrackout = b.UrlTrackout,

                UrlCover = b.UrlCover,
            };
        }

    }
}