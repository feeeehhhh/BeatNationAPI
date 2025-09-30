using BeatNationAPI.DTOs.Licencas;
using BeatNationAPI.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.DTOs.Beats
{
    public class BeatCreateDto
    {

        public int Id { get; set; }  
        public int IdUsuario { get; set; }  // ID pegado via token
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
        public ICollection<BeatLicencaReadDto> Licencas { get; set; } = new List<BeatLicencaReadDto>();

        public static implicit operator Beat(BeatCreateDto dto)
        {
            {
                return new Beat
                {
                    IdUsuario = dto.IdUsuario,
                    Nome = dto.Nome,
                    Tags = dto.Tags,
                    Genero = dto.Genero,
                    Bpm = dto.Bpm,
                    ISRC = dto.ISRC,
                    Escala = dto.Escala,
                    Tom = dto.Tom,
                    UrlMP3 = dto.UrlMP3,
                    UrlWAV = dto.UrlWAV,
                    UrlTRACKOUT = dto.UrlTRACKOUT,
                    UrlCAPA = dto.UrlCAPA,

                    // Conversão automática pq o BeatColabCreateDto tem implicit → BeatColab
                    Colaboradores = dto.Colaboradores?
                    .Select(c => (BeatColab)c)
                    .ToList() ?? new List<BeatColab>(),

                       Licencas = dto.Licencas?
                        .Select(c => new BeatLicencas
                        {
                            Id = dto.Id,
                            NomeLicencas = c.NomeLicencas,
                            Preco = c.Preco,
                            Distribuicao = c.Distribuicao,
                            StreamingAudio = c.StreamingAudio,
                            StreamingVideo = c.StreamingVideo,
                            Video = c.Video,
                            ApresenFimLucrativos = c.ApresenFimLucrativos,
                            ApresenSemFinsLucrativos = c.ApresenSemFinsLucrativos,
                            ExibirEmissoraRadio = c.ExibirEmissoraRadio,
                            ExibirEmissoraTV = c.ExibirEmissoraTV,
                            CriadoEm = DateTime.Now,
                            AtualizadoEm = DateTime.Now,
                        })
                        .ToList() ?? new List<BeatLicencas>(),
                };
            }

        }
    }
}
