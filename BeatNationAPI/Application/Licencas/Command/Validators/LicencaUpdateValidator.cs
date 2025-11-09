using FluentValidation;
using BeatNationAPI.Application.Licencas.Command.Request;

namespace BeatNationAPI.Application.Licencas.Command.Validators
{
    public class LicencaUpdateValidator : AbstractValidator<LicencaUpdateRequest>
    {
        public LicencaUpdateValidator()
        {
            
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome da licença é obrigatório!")
            .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres!")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres!")
            .Matches("^[A-Za-zÀ-ÿ0-9 ,.()-]+$").WithMessage("O campo deve conter apenas letras e números.");

            RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("O nome da licença é obrigatório!")
            .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres!")
            .MaximumLength(200).WithMessage("O nome deve ter no máximo 200 caracteres!")
            .Matches("^[A-Za-zÀ-ÿ0-9 ,.()-]+$").WithMessage("O campo deve conter apenas letras e números.");

            RuleFor(x => x.Categoria)
            .NotEmpty().WithMessage("A categoria da licença é obrigatória!")
            .MinimumLength(3).WithMessage("A categoria deve ter no mínimo 3 caracteres!")
            .MaximumLength(50).WithMessage("A categoria deve ter no máximo 50 caracteres!")
            .Matches("^[A-Za-z0-9]+$").WithMessage("O campo deve conter apenas letras e números.");

            RuleFor(x => x.PeriodoUso)
            .NotNull().WithMessage("O período de uso é obrigatório!");

            RuleFor(x => x.Distribuicao)
            .NotNull().WithMessage("O numero de distribuição é obrigatório!");

            RuleFor(x => x.StreamingAudio)
            .NotNull().WithMessage("O número de streamings de audio obrigatório!");

            RuleFor(x => x.StreamingVideo)
            .NotNull().WithMessage("O número de streamings de vídeo obrigatório!!");

            RuleFor(x => x.Video)
            .NotNull().WithMessage("O número de videos clips é obrigatório!");

            RuleFor(x => x.ApresenSemFinsLucrativos)
            .NotNull().WithMessage("A quantidade de apresentações sem fins lucrativos é obrigatório!");

            RuleFor(x => x.ApresenFimLucrativos)
            .NotNull().WithMessage("A quantidade de apresentações com fins lucrativos é obrigatório!");

            RuleFor(x => x.Porcentagem)
            .NotNull().WithMessage("A porcentagem é obrigatória!")
            .InclusiveBetween(0, 100).WithMessage("A porcentagem deve estar entre 0 e 100.");

            RuleFor(x => x.RoyaltShare)
            .NotNull().WithMessage("O Royalty Share é obrigatório!")
            .InclusiveBetween(0, 100).WithMessage("O Royalty Share deve estar entre 0 e 100.");

            RuleFor(x => x.ExibirEmissoraRadio)
            .NotNull().WithMessage("O campo Exibir Emissora Rádio é obrigatório!");

            RuleFor(x => x.ExibirEmissoraTV)
            .NotNull().WithMessage("O campo Exibir Emissora TV é obrigatório!");


            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O ID é obrigatório para atualização.");
        }
    }
}