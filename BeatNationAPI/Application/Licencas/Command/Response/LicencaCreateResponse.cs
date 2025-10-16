using MediatR;
using BeatNationAPI.Application.Licencas.Command.Response;
using System.Collections.Generic;
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Command.Licencas.Request
{
    public class LicencaCreateResponse
    {

        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public Guid? OwnerId { get; set; }
        public Guid PresetLicencaId { get; set; }
        public List<LicencaConfig> LicencaConfig { get; set; } = new();

        public static implicit operator LicencaCreateResponse(Licenca l)
        {
            return new LicencaCreateResponse
            {
                Id = l.Id,
                Nome = l.Nome,
                Descricao = l.Descricao,
                Categoria = l.Categoria,
                OwnerId = l.OwnerId,
                PresetLicencaId = l.PresetLicencaId,
                LicencaConfig = l.LicencaConfig?
                .Select(lc => (LicencaConfig)lc)
                .ToList()
            };
        }
    }
}
