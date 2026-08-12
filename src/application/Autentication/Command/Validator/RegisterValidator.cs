using src.application.Autentication.Command.Request;
using FluentValidation;

namespace src.application.Autentication.Command.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório!")
                .MaximumLength(200).WithMessage("O email deve ter no máximo 200 caracteres")
                .EmailAddress().WithMessage("O email deve ser válido!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória!")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres!")
                .MaximumLength(50).WithMessage("A senha deve ter no máximo 50 caracteres!");


            RuleFor(x => x.PhoneNumber)
    .Matches(@"^\d{10,11}$")
    .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório!")
                .MinimumLength(2).WithMessage("O nome deve ter no mínimo 2 caracteres!")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres!");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório!")
                .MinimumLength(3).WithMessage("O nome de usuário deve ter no mínimo 3 caracteres!")
                .MaximumLength(30).WithMessage("O nome de usuário deve ter no máximo 30 caracteres!");
        }
    }
}