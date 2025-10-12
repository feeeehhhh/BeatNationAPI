using BeatNationAPI.Application.Beats.Command.Request;
using FluentValidation;

namespace BeatNationAPI.Application.Beats.Command.Validators
{
    public class BeatCreateValidator : AbstractValidator<BeatCreateRequest>
    {
        public BeatCreateValidator()
        {
            RuleFor(x => x.Nome) // obrigatorio
            .NotEmpty().WithMessage("O nome do beat é obrigatório!") 
            .MinimumLength(10).WithMessage("O nome deve ter no mínimo 10 caracteres!")
            .MaximumLength(150).WithMessage("O Nome deve ter no máximo 150 caracteres!");


            RuleFor(x => x.Tags) // opcional
                .MinimumLength(2).WithMessage("O Nome deve ter no mínimo 2 caracteres!")
                .MaximumLength(150).WithMessage("As tags devem ter no máximo 150 caracteres!");



            RuleFor(x => x.Genero) // obrigatorio
            .NotEmpty().WithMessage("É obrigatório definir um tipo de gênero!")
            .MaximumLength(150);

            RuleFor(x => x.ISRC) // opcional
                .MaximumLength(12).WithMessage("O código ISRC deve ter  12 caracteres!")
                .MinimumLength(12).WithMessage("O código ISRC deve ter  12 caracteres!");

            RuleFor(x => x.Escala)// opcional
                .MinimumLength(1).WithMessage("A escala deve ter pelo menos 1 caractere")
                .MaximumLength(20).WithMessage("A escala deve ter no máximo 20 caracteres");

            RuleFor(x => x.UrlMp3) // obrigatorio   
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