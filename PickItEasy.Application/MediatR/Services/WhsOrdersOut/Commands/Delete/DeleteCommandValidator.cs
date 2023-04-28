using FluentValidation;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Commands.Delete
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(deleteWhsOrderOutCommand => deleteWhsOrderOutCommand.Id).NotNull().NotEmpty();
        }
    }
}
