using System.Data;
using src.application.Autentication.Command.Request;
using FluentValidation;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;


namespace src.application.Autentication.Command.Validator
{
    public class LoginValidator : AbstractValidator<LoginUserRequest>
    {
       public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório!")
                .MaximumLength(200).WithMessage("O email deve ter no máximo 200 caracteres")
                .EmailAddress().WithMessage("O email deve ser válido!");
        }
    }
}