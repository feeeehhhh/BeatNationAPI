
using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Common.Responses;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public class BeatLicencaCreateRequest : IRequest<Response<BeatLicencaResponse>>
    {

        public Guid BeatId { get; set; }
        public Guid LicencaId { get; set; }
        public decimal Preco { get; set; }


        public static implicit operator BeatLicencas(BeatLicencaCreateRequest bl)
        {
            return new BeatLicencas
            {

                BeatId = bl.BeatId,
                LicencaId = bl.LicencaId,
                Preco = bl.Preco
            };
        }


    }

}
