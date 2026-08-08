
// using src.Common.Responses;
// using src.Models;
// using MediatR;

// namespace src.features.Licencas.Command.Request
// {
//     public record LicencaUpdateRequest(
//     Guid Id,
//     string? Nome,
//     string? Descricao,
//     string? Categoria,
//     ValorOuIlimitado? PeriodoUso,
//     ValorOuIlimitado? Distribuicao,
//     ValorOuIlimitado? StreamingAudio,
//     ValorOuIlimitado? StreamingVideo,
//     ValorOuIlimitado? Video,
//     ValorOuIlimitado? ApresenSemFinsLucrativos,
//     ValorOuIlimitado? ApresenFimLucrativos,
//     int? Porcentagem,
//     int? RoyaltShare,
//     bool? ExibirEmissoraRadio,
//     bool? ExibirEmissoraTV

// ) : IRequest<Response<Guid>>;
// }