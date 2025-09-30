using BeatNationAPI.Models;

namespace BeatNationAPI.DTOs.Beats
{
    public class BeatColabReadDto
    {
        public Guid IdUsuario { get; set; }      // ID do colaborador
        public decimal Participacao { get; set; } // Percentual de participaçãoadadadad

        public static implicit operator BeatColabReadDto(BeatColab entity)
        {
            return new BeatColabReadDto
            {
                IdUsuario = entity.IdUsuario,
                Participacao = entity.Participacao,
            };
        }
    }
}
