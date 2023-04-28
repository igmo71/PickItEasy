using FluentValidation;
using PickItEasy.Application.MediatR.Validation;

namespace PickItEasy.Application.MediatR.Services.BaseDocuments.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(createCommand => createCommand.BaseDocumentDto).NotNull().NotEmpty().SetValidator(new BaseDocumentDtoValidator());
        }
    }
}
