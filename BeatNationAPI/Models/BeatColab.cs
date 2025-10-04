using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.Models
{
    public class BeatColab
    {
        public Guid Id { get; set; }

        public Guid BeatId { get; set; } //Chave estrangeira do Beat

        [Required]
        public Beat Beat { get; set; }

        public int IdUsuario { get; set; }  // ID do colaborador/produtor/
        public decimal Participacao { get; set; }
    }
}
