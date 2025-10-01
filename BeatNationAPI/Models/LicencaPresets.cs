namespace BeatNationAPI.Models
{
    public class LicencaPresets : Licenca
    {
        // Novo: vincular ao usuário que criou o preset
        public Guid IdUsuario { get; set; }  // ID do colaborador/produtor
        public Guid PresetId { get; set; }   // Id único do preset
        public string NomePreset { get; set; } = string.Empty;

        public DateTime CriadoEm {  get; set; }
        public DateTime AtualizadoEm { get; set ; }

    }
}
