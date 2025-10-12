


    
namespace BeatNationAPI.Models
{
    public class BeatLicencas
    {
        
        public Guid Id { get; set; }

        // Relacionamento com Beat
        public Guid BeatId { get; set; }
        public Beat? Beat { get; set; } // agora pode ser nulo


        public decimal Preco { get; set; }
        // Relacionamento com Licença
        public Guid PresetLicencaId { get; set; }
        public LicencaBase Licenca { get; set; }
    }
}

        
    
