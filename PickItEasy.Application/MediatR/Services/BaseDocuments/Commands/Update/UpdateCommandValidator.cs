using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.MediatR.Services.BaseDocuments.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(updateCommand => updateCommand.Id).NotNull().NotEmpty();
            RuleFor(updateCommand => updateCommand.BaseDocumentDto).NotNull().NotEmpty().SetValidator(new BaseDocumentDtoValidator());
        }
    }
}
