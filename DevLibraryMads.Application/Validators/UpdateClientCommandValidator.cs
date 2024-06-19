﻿using DevLibraryMads.Application.Commands.UpdateClient;
using FluentValidation;

namespace DevLibraryMads.Application.Validators
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(c => c.FullName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("O nome precisar ter no minimo 3 caracteres");

            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Email inválido, informe um e-mail válido");
        }
    }
}
