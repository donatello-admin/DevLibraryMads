using DevLibraryMads.Application.Commands.FinishOrder;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace DevLibraryMads.Application.Validators
{
    public class FinishOrderCommandValidator : AbstractValidator<FinishOrderCommand>
    {
        public FinishOrderCommandValidator()
        {
            RuleFor(fo => fo.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id não pode ser nulo ou vazio");

            RuleFor(fo => fo.CardNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("O CardNumber não pode ser nulo ou vazio");

            RuleFor(fo => fo.DtExpired)
                .Must(ValidaDtExpired)
                .WithMessage("A data de expiração deve ser superior ao mês e ano atual.");

            RuleFor(fo => fo.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O FullName não pode ser nulo ou vazio");
        }

        private bool ValidaDtExpired(string dtexpired)
        {
            if (!DateTime.TryParse(dtexpired, out var dtExpired))
            {
                return false;
            }

            var now = DateTime.Now;
            return dtExpired.Year > now.Year || (dtExpired.Year == now.Year && dtExpired.Month > now.Month);
        }
    }
}
