using FluentValidation;
using PickItEasy.Application.MediatR.Validation;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(createCommand => createCommand.WhsOrderOutDto).NotNull().NotEmpty().SetValidator(new WhsOrderOutDtoValidator());
        }
    }
}
