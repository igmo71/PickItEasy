using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(createCommand => createCommand.WhsOrderOutDto).NotNull().NotEmpty();
            RuleFor(createCommand => createCommand.WhsOrderOutDto).SetValidator(new WhsOrderOutDtoValidator());
        }
    }
}
