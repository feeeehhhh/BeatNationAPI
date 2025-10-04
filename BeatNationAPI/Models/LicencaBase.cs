using System.ComponentModel.DataAnnotations;

namespace BeatNationAPI.Models
{
    public class LicencaBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = ""; // Basica,VIP, Exclusiva

        public List<PresetLicencaConfig> Presets { get; set; } = new();
    }


}

