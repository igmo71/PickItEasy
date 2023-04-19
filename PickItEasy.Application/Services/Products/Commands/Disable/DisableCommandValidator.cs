using FluentValidation;

namespace PickItEasy.Application.Services.Products.Commands.Disable
{
    public class DisableCommandValidator : AbstractValidator<DisableCommand>
    {
        public DisableCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
