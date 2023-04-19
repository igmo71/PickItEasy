using FluentValidation;
using PickItEasy.Application.Dtos.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.BaseDocuments.Commands.Update
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
