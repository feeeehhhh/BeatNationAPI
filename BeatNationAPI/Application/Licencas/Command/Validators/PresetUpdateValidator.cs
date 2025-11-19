using BeatNationAPI.Application.Licencas.Command.Request;
using FluentValidation;

namespace BeatNationAPI.Application.Licencas.Command.Validators
{
    public class PresetUpdateValidator : AbstractValidator<PresetUpdateRequest>
    {
        public PresetUpdateValidator()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do preset é obrigatório!")
            .MinimumLength(5).WithMessage("O nome deve ter no mínimo 5 caracteres!")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres!")
            .Matches("^[A-Za-zÀ-ÿ0-9 ,.()-]+$").WithMessage("O campo deve conter apenas letras e números.");

            RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("A descrição do preset é obrigatória!")
            .MinimumLength(5).WithMessage("A descrição deve ter no mínimo 5 caracteres!")
            .MaximumLength(200).WithMessage("A descrição deve ter no máximo 200 caracteres!")
            .Matches("^[A-Za-zÀ-ÿ0-9 ,.()-]+$").WithMessage("O campo deve conter apenas letras e números.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O ID é obrigatório para atualização.");
                
        }
    }
}