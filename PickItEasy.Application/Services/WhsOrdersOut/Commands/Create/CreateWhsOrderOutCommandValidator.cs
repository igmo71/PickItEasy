using FluentValidation;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommandValidator : AbstractValidator<CreateWhsOrderOutCommand>
    {
        public CreateWhsOrderOutCommandValidator()
        {
            RuleFor(createWhsOrderOutCommand => createWhsOrderOutCommand.WhsOrderOutDto).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutCommand => createWhsOrderOutCommand.WhsOrderOutDto).SetValidator(new WhsOrderOutDtoValidator());
        }
    }        
}
