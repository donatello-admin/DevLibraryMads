using DevLibraryMads.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevLibraryMads.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("UserName é obrigatório");

            RuleFor(p => p.Password)
                .Must(ValidaPassword)
                .WithMessage("Senha deve contér 8 caracteres, uma maíuscula, uma minuscula, um número e um caractere especial.");

            RuleFor(r => r.Role)
                .Must(ValidaRole)
                .WithMessage("Role inválida");

        }

        public bool ValidaPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=].*$)");

            return regex.IsMatch(password);
        }

        public bool ValidaRole(string role)
        {
            if(role != "admin" &&  role != "client")
                return false;
            return true;
        }
    }
}
