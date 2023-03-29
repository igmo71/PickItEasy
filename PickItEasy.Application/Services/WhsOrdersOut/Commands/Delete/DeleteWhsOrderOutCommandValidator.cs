using FluentValidation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete
{
    public class DeleteWhsOrderOutCommandValidator : AbstractValidator<DeleteWhsOrderOutCommand>
    {
        public DeleteWhsOrderOutCommandValidator()
        {
            RuleFor(deleteWhsOrderOutCommand => deleteWhsOrderOutCommand.Id).NotNull().NotEmpty();
        }
    }
}
