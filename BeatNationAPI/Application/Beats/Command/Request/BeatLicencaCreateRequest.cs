<<<<<<< HEAD
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public class BeatLicencaCreateRequest
    {
        public Guid Id { get; set; }
        public Guid BeatId { get; set; }
        public Guid LicencaId { get; set; }
        public int Preco { get; set; }
        public required ValorOuIlimitado PeriodoUso { get; set; }
        public required ValorOuIlimitado Distribuicao { get; set; }
        public required ValorOuIlimitado StreamingAudio { get; set; }
        public required ValorOuIlimitado StreamingVideo { get; set; }
        public required ValorOuIlimitado Video { get; set; }
        public required ValorOuIlimitado ApresenSemFinsLucrativos { get; set; }
        public required ValorOuIlimitado ApresenFimLucrativos { get; set; }
        public int Porcentagem { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }
    }
}
=======

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
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
