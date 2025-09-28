namespace BeatNationAPI.Models
{
    public class LicencaPresets : Licenca
    {
        // Novo: vincular ao usuário que criou o preset
        public Guid IdUsuario { get; set; }  // ID do colaborador/produtor
        public string Descricao { get; set; } = string.Empty;

    }
}
