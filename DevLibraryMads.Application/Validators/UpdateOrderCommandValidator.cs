using DevLibraryMads.Application.Commands.UpdateOrder;
using FluentValidation;

namespace DevLibraryMads.Application.Validators
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(o => o.NumPedVda)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("O pedido precisa ter no mínimo 3 caracteres");
        }
    }
}
