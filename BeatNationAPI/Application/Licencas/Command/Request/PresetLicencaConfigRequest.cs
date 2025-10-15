using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Models;
using MediatR;

public class PresetLicencaConfigRequest : IRequest<PresetLicencaConfigResponse>
{

    public Guid Id { get; set; }
    public Guid LicencasId { get; set; }

    // Configurações do preset

    public required ValorOuIlimitado PeriodoUso { get; set; }
    public required ValorOuIlimitado Distribuicao { get; set; }
    public required ValorOuIlimitado StreamingAudio { get; set; }
    public required ValorOuIlimitado StreamingVideo { get; set; }
    public required ValorOuIlimitado Video { get; set; }
    public required ValorOuIlimitado ApresenSemFinsLucrativos { get; set; }
    public required ValorOuIlimitado ApresenFimLucrativos { get; set; }
    public int Preco { get; set; }
    public int Porcentagem { get; set; }
    public int RoyaltShare { get; set; }
    public bool ExibirEmissoraRadio { get; set; }
    public bool ExibirEmissoraTV { get; set; }

    public static implicit operator PresetLicencaConfig(PresetLicencaConfigRequest l)
    {
        return new PresetLicencaConfig
        {
            Id = l.Id,
            LicencasId = l.LicencasId,
            PeriodoUso = l.PeriodoUso,
            Distribuicao = l.Distribuicao,
            StreamingAudio = l.StreamingAudio,
            StreamingVideo = l.StreamingVideo,
            Video = l.Video,
            ApresenSemFinsLucrativos = l.ApresenSemFinsLucrativos,
            ApresenFimLucrativos = l.ApresenFimLucrativos,
            Preco = l.Preco,
            Porcentagem = l.Porcentagem,
            RoyaltShare = l.RoyaltShare,
            ExibirEmissoraRadio = l.ExibirEmissoraRadio,
            ExibirEmissoraTV = l.ExibirEmissoraTV
        };
    }
}