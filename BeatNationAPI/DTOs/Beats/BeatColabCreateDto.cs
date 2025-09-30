using BeatNationAPI.Models;

namespace BeatNationAPI.DTOs.Beats
{
    public class BeatColabCreateDto
    {
        public Guid IdUsuario { get; set; }      // ID do colaborador
        public decimal Participacao { get; set; } // Percentual de participação

        public static implicit operator BeatColab(BeatColabCreateDto dto)
        {
            return new BeatColab
            {
                IdUsuario = dto.IdUsuario,
                Participacao = dto.Participacao
            };
        }
    }
}
