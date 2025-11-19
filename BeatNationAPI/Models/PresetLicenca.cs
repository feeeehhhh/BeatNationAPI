namespace BeatNationAPI.Models
{
public class PresetLicenca
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public Guid? OwnerId { get; set; }

    public List<Licenca> Licencas { get; set; } = new();
}

}
