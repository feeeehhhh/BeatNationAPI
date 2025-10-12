namespace BeatNationAPI.Models
{
public class PresetLicenca
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public Guid? OwnerId { get; set; }

    public List<PresetLicencaConfig> Licencas { get; set; } = new();
}

}
