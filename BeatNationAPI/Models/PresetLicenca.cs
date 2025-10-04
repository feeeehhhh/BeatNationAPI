namespace BeatNationAPI.Models
{
public class PresetLicenca
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = "";
    public string Descricao { get; set; } = "";
    public Guid OwnerId { get; set; }

    public List<PresetLicencaConfig> Licencas { get; set; } = new();
}

}
