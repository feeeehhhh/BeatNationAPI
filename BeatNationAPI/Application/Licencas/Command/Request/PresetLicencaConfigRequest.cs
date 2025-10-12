using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Models;
using MediatR;

public class PresetLicencaConfigRequest : IRequest<PresetLicencaConfigResponse>
{

    public Guid  Id { get; set; }
    public Guid LicencaBaseId { get; set; }

    // Backing fields
    private int _periodoUso;
    private int _distribuicao;
    private int _streamingAudio;
    private int _streamingVideo;
    private int _video;
    private int _apresenSemFinsLucrativos;
    private int _apresenFimLucrativos;

    // Propriedades com conversão implícita
    public string PeriodoUso
    {
        set => _periodoUso = value == "Ilimitado" ? 999999 : int.Parse(value);
        get => _periodoUso == 999999 ? "Ilimitado" : _periodoUso.ToString();
    }

    public string Distribuicao
    {
        set => _distribuicao = value == "Ilimitado" ? 999999 : int.Parse(value);
        get => _distribuicao == 999999 ? "Ilimitado" : _distribuicao.ToString();
    }

    public string StreamingAudio
    {
        set => _streamingAudio = value == "Ilimitado" ? 999999 : int.Parse(value);
        get => _streamingAudio == 999999 ? "Ilimitado" : _streamingAudio.ToString();
    }

    public string StreamingVideo
    {
        set => _streamingVideo = value == "Ilimitado" ? 999999 : int.Parse(value);
        get => _streamingVideo == 999999 ? "Ilimitado" : _streamingVideo.ToString();
    }

    public string Video
    {
        set => _video = value == "Ilimitado" ? 999999 : int.Parse(value);
        get => _video == 999999 ? "Ilimitado" : _video.ToString();
    }

    public string ApresenSemFinsLucrativos
    {
        set => _apresenSemFinsLucrativos = value == "Ilimitado" ? 999999 : int.Parse(value);
        get => _apresenSemFinsLucrativos == 999999 ? "Ilimitado" : _apresenSemFinsLucrativos.ToString();
    }

    public string ApresenFimLucrativos
    {
        set => _apresenFimLucrativos = value == "Ilimitado" ? 999999 : int.Parse(value);
        get => _apresenFimLucrativos == 999999 ? "Ilimitado" : _apresenFimLucrativos.ToString();
    }

    // Propriedades normais
    public int Preco { get; set; }
    public int Porcentagem { get; set; }
    public int RoyaltShare { get; set; }
    public bool ExibirEmissoraRadio { get; set; }
    public bool ExibirEmissoraTV { get; set; }

    // Métodos para retornar int para salvar no banco
    public int PeriodoUsoInt => _periodoUso;
    public int DistribuicaoInt => _distribuicao;
    public int StreamingAudioInt => _streamingAudio;
    public int StreamingVideoInt => _streamingVideo;
    public int VideoInt => _video;
    public int ApresenSemFinsLucrativosInt => _apresenSemFinsLucrativos;
    public int ApresenFimLucrativosInt => _apresenFimLucrativos;

    public static implicit operator PresetLicencaConfig(PresetLicencaConfigRequest l)
    {
        return new PresetLicencaConfig
        {
            Id = l.Id,
            LicencaBaseId = l.LicencaBaseId,
            PeriodoUso = l.PeriodoUsoInt,
            Distribuicao = l.DistribuicaoInt,
            StreamingAudio = l.StreamingAudioInt,
            StreamingVideo = l.StreamingVideoInt,
            Video = l.VideoInt,
            ApresenSemFinsLucrativos = l.ApresenSemFinsLucrativosInt,
            ApresenFimLucrativos = l.ApresenFimLucrativosInt,
            Preco = l.Preco,
            Porcentagem = l.Porcentagem,
            RoyaltShare = l.RoyaltShare,
            ExibirEmissoraRadio = l.ExibirEmissoraRadio,
            ExibirEmissoraTV = l.ExibirEmissoraTV
        };
    }
}