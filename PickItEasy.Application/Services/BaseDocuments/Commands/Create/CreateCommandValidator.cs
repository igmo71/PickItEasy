using FluentValidation;
using PickItEasy.Application.Dtos.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
