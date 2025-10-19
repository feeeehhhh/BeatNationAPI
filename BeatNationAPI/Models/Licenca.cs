

using System.Text.Json.Serialization;

namespace BeatNationAPI.Models
{
    public class Licenca
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public Guid? OwnerId { get; set; }

        public Guid PresetLicencaId { get; set; }

        [JsonIgnore] // Evita referência circular na serialização JSON
        public PresetLicenca? PresetLicenca { get; set; }

        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
         public ICollection<LicencaConfig> LicencaConfig { get; set; } = new List<LicencaConfig>();
        
    }


}

