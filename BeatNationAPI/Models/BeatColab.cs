

<<<<<<< HEAD
using System.Text.Json.Serialization;

=======
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
namespace BeatNationAPI.Models
{
    public class BeatColab
    {
        public Guid Id { get; set; }
<<<<<<< HEAD

        public Guid BeatId { get; set; } //Chave estrangeira do Beat
        
        [JsonIgnore]
        public Beat? Beat { get; set; } // agora pode ser nulo
        public string Username { get; set; } = string.Empty; // Nome do colaborador/produtor

        public int IdUsuario { get; set; }  // ID do colaborador/produtor/
=======
        public Guid BeatId { get; set; } //Chave estrangeira do Beat
        public Beat? Beat { get; set; } // agora pode ser nulo
        public string Username { get; set; } = string.Empty; // Nome do colaborador/produtor
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
        public decimal Participacao { get; set; }
    }
}
