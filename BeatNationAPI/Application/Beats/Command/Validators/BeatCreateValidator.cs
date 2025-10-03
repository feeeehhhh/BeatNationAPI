using BeatNationAPI.Application.Beats.Command.Request;
using FluentValidation;

namespace BeatNationAPI.Application.Beats.Command.Validators
{
    public class BeatCreateValidator : AbstractValidator<BeatCreateRequest>
    {
        public BeatCreateValidator()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do beat é obrigatório !");
        }
    }
}