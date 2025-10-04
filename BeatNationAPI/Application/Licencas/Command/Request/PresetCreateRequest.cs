using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Command.Licencas.Request
{
        public class PresetCreateRequest : IRequest<Guid>
        {
                public string Nome { get; set; }
                public string Descricao { get; set; }
                public List<LicencaPresetRequest> Licencas { get; set; } = new();



        }


}
