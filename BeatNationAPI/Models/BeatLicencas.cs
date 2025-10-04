


    
namespace BeatNationAPI.Models
{
    public class BeatLicencas
    {
        
        public Guid Id { get; set; }

        // Relacionamento com Beat
        public Guid BeatId { get; set; }
        public Beat Beat { get; set; }

        // Relacionamento com Licença
        public int LicencaId { get; set; }
        public LicencaBase Licenca { get; set; }
    }
}

        
    
