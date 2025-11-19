
using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Common.Responses;
using BeatNationAPI.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Licencas.Handlers
{
    public class LicencaUpdateHandler : IRequestHandler<LicencaUpdateRequest, Response<Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IValidator<LicencaUpdateRequest> _validator;
        public LicencaUpdateHandler(AppDbContext context, IValidator<LicencaUpdateRequest> validator)
        {
            _context = context;
            _validator = validator;
           
        }

        public async Task<Response<Guid>> Handle(LicencaUpdateRequest request, CancellationToken cancellationToken)
        {

            // Valida o request
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
                        if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Response<Guid>.Fail("Falha na validação" + errors);
            }


            // Busca a licença
            var licenca = await _context.Licencas
                .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

            if (licenca == null)
                return Response<Guid>.Fail("Licença não encontrada.");

            // Atualiza os dados principais
            licenca.Nome = request.Nome ?? licenca.Nome;
            licenca.Descricao = request.Descricao ?? licenca.Descricao;
            licenca.Categoria = request.Categoria ?? licenca.Categoria;

            // Atualiza os campos que antes ficavam na LicencaConfig
            licenca.PeriodoUso = request.PeriodoUso ?? licenca.PeriodoUso;
            licenca.Distribuicao = request.Distribuicao ?? licenca.Distribuicao;
            licenca.StreamingAudio = request.StreamingAudio ?? licenca.StreamingAudio;
            licenca.StreamingVideo = request.StreamingVideo ?? licenca.StreamingVideo;
            licenca.Video = request.Video ?? licenca.Video;
            licenca.ApresenSemFinsLucrativos = request.ApresenSemFinsLucrativos ?? licenca.ApresenSemFinsLucrativos;
            licenca.ApresenFimLucrativos = request.ApresenFimLucrativos ?? licenca.ApresenFimLucrativos;
            licenca.Porcentagem = request.Porcentagem ?? licenca.Porcentagem;
            licenca.RoyaltShare = request.RoyaltShare ?? licenca.RoyaltShare;
            licenca.ExibirEmissoraRadio = request.ExibirEmissoraRadio ?? licenca.ExibirEmissoraRadio;
            licenca.ExibirEmissoraTV = request.ExibirEmissoraTV ?? licenca.ExibirEmissoraTV;
            await _context.SaveChangesAsync(cancellationToken);
            return Response<Guid>.Ok(licenca.Id, "Licença atualizada com sucesso !");
        }

    }
}