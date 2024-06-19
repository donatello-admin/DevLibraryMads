using DevLibraryMads.Application.Commands.CreateOrder;
using FluentValidation;

namespace DevLibraryMads.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.NumPedVda)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("O pedido precisa ter no mínimo 3 caracteres");
        }
    }
}
