using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(createCommand => createCommand.BaseDocumentDto).NotNull().NotEmpty().SetValidator(new BaseDocumentDtoValidator());
        }
    }
}
