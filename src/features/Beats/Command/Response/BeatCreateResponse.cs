using src.features.Beats.Command.Request;
using src.domain.models;

namespace src.features.Beats.Command.Response
{
    public class BeatCreateResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int? Bpm { get; set; }
        public string ISRC { get; set; } = string.Empty;
        public string Scale { get; set; } = string.Empty;
        public string Tone { get; set; } = string.Empty;
        public string UrlMp3 { get; set; } = string.Empty;
        public string UrlWav { get; set; } = string.Empty;
        public string UrlTrackout { get; set; } = string.Empty;
        public string UrlCover { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        


        public static implicit operator BeatCreateResponse(Beat b)
        {
            return new BeatCreateResponse
            {
                Id = b.Id,
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
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt,
            };
        }
    }
};