
using System.Text.Json.Serialization;
using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Licencas.Command.Response
{
    public class PresetCreateResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid? OwnerId { get; set; }

        public ICollection<LicencaCreateResponse> Licencas { get; set; } = new List<LicencaCreateResponse>();


        public static implicit operator PresetCreateResponse(PresetLicenca p)
        {
            return new PresetCreateResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                OwnerId = p.OwnerId,
                Licencas = p.Licencas?
                    .Select(l => (LicencaCreateResponse)l) // converte cada item individualmente
                   .ToList()
            };
        }

    }
}