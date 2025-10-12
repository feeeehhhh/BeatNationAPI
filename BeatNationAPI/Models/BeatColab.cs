

namespace BeatNationAPI.Models
{
    public class BeatColab
    {
        public Guid Id { get; set; }

        public Guid BeatId { get; set; } //Chave estrangeira do Beat
        public Beat? Beat { get; set; } // agora pode ser nulo
        public string Username { get; set; } = string.Empty; // Nome do colaborador/produtor

        public int IdUsuario { get; set; }  // ID do colaborador/produtor/
        public decimal Participacao { get; set; }
    }
}
