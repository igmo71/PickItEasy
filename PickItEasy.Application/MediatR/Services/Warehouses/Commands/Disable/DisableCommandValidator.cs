using FluentValidation;

namespace PickItEasy.Application.MediatR.Services.Warehouses.Commands.Disable
{
    public class DisableCommandValidator : AbstractValidator<DisableCommand>
    {
        public DisableCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
