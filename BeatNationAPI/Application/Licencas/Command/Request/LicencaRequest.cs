using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Models;
using MediatR;

public class LicencaRequest : IRequest<LicencaResponse>
{

    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public Guid? OwnerId { get; set; }

    public Guid PresetLicencaId { get; set; }

    public List<LicencaConfig> LicencaConfig { get; set; } = new();

    public static implicit operator Licenca(LicencaRequest l)
    {
        return new Licenca
        {
            Id = l.Id,
            Nome = l.Nome,
            Descricao = l.Descricao,
            LicencaConfig = l.LicencaConfig?
            .Select(lc => (LicencaConfig)lc)
            .ToList()

            
        };
    }
}