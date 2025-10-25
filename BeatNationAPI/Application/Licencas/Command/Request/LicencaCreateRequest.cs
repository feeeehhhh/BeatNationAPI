
using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command.Request
{
    public class LicencaCreateRequest : IRequest<LicencaCreateResponse>
    {

        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public Guid? OwnerId { get; set; }

        public Guid PresetLicencaId { get; set; }

        public List<LicencaConfigCreateRequest> LicencaConfig { get; set; } = new();

        public static implicit operator Licenca(LicencaCreateRequest l)
        {
            return new Licenca
            {
                Id = l.Id,
                Nome = l.Nome,
                Descricao = l.Descricao,
                LicencaConfig = l.LicencaConfig
                .Select(lc => (LicencaConfig)lc)
                .ToList()


            };
        }
    }
}
