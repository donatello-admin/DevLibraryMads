using DevLibraryMads.Application.Commands.UpdateBook;
using FluentValidation;

namespace DevLibraryMads.Application.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("O Título precisa ter no mínimo 5 caracteres");

            RuleFor(b => b.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição é obrigatória");


            RuleFor(b => b.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Autor é obrigatório");

        }
    }
}
