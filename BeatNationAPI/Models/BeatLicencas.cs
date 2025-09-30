using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.Models
{
    public class BeatLicencas : LicencaPresets
    {
        public int Id { get; set; }
        // Chave estrangeira para Beat
        public int BeatId { get; set; }
        public Beat Beat { get; set; }

        
    }
}
