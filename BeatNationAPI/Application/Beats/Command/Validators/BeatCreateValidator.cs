using BeatNationAPI.Application.Beats.Command.Request;
using FluentValidation;

namespace BeatNationAPI.Application.Beats.Command.Validators
{
    public class BeatCreateValidator : AbstractValidator<BeatCreateRequest>
    {
        public BeatCreateValidator()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do beat é obrigatório!")
            .MinimumLength(10).WithMessage("O nome deve ter no mínimo 10 caracteres!")
            .MaximumLength(150).WithMessage("O Nome deve ter no máximo 150 caracteres!");


            RuleFor(x => x.Genero)
            .NotEmpty().WithMessage("É obrigatório definir um tipo de gênero!");


            RuleFor(x => x.UrlMp3)
            .NotEmpty()
            .MaximumLength(300);

            RuleFor(x => x.UrlWav)
            .NotEmpty()
            .MaximumLength(300);

            RuleFor(x => x.UrlTrackout)
            .NotEmpty()
            .MaximumLength(300);

            RuleFor(x => x.UrlCapa)
            .NotEmpty()
            .MaximumLength(300);
             

             // Adicionar regras para Licencas e Colab Dps


        }
    }
}