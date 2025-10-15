

namespace BeatNationAPI.Models
{
    public class Licencas
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public Guid? OwnerId { get; set; } // null para licenças padrão
        public List<PresetLicencaConfig> Presets { get; set; } = new();
    }


}

