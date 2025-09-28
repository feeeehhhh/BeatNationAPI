using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.Models
{
    public class BeatLicencas : Licenca
    {
        public int Id { get; set; }
        // Chave estrangeira para Beat
        public Guid BeatId { get; set; }
        public Beat Beat { get; set; }

        
    }
}
