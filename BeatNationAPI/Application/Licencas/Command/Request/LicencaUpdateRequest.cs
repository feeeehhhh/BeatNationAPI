using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command.Request
{
    public record LicencaConfigUpdateRequest(
        Guid Id,
        Guid LicencasId,
        ValorOuIlimitado? PeriodoUso,
        ValorOuIlimitado? Distribuicao,
        ValorOuIlimitado? StreamingAudio,
        ValorOuIlimitado? StreamingVideo,
        ValorOuIlimitado? Video,
        ValorOuIlimitado? ApresenSemFinsLucrativos,
        ValorOuIlimitado? ApresenFimLucrativos,
        int? Preco,
        int? Porcentagem,
        int? RoyaltShare,
        bool? ExibirEmissoraRadio,
        bool? ExibirEmissoraTV

    ): IRequest;

    public record LicencaUpdateRequest(
    Guid Id,
    string? Nome,
    string? Descricao,
    string? Categoria,
    List<LicencaConfig>? LicencaConfig
) : IRequest;
}