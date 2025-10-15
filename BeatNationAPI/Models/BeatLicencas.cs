



using System.Text.Json.Serialization;

namespace BeatNationAPI.Models
{
    public class BeatLicencas
    {
        
        public Guid Id { get; set; }

        // Relacionamento com Beat
        public Guid BeatId { get; set; }
        
        [JsonIgnore] // Evita referência circular na serialização JSON
        public Beat? Beat { get; set; } // agora pode ser nulo


        public decimal Preco { get; set; }
        // Relacionamento com Licença
        public Guid PresetLicencaId { get; set; }
        
        [JsonIgnore] // Evita referência circular na serialização JSON
        public Licencas Licenca { get; set; }
    }
}

        
    
