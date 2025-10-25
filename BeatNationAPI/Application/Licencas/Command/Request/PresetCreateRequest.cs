using System.Text.Json.Serialization;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Command.Licencas.Request
{
        public class PresetCreateRequest : IRequest<PresetCreateResponse>
        {
                public Guid Id { get; set; }
                public string Nome { get; set; }
                public string Descricao { get; set; }
                public Guid? OwnerId { get; set; }

                [JsonIgnore]
                public List<Licenca> Licencas { get; set; } = new();


                public static implicit operator PresetLicenca(PresetCreateRequest p)
                {
                        return new PresetLicenca
                        {
                                Id = p.Id,
                                Nome = p.Nome,
                                Descricao = p.Descricao,
                                OwnerId = p.OwnerId,
                                Licencas = p.Licencas?
                                .Select(l => (Licenca)l) // converte cada item individualmente
                               .ToList()
                        };
                }


    }


}
