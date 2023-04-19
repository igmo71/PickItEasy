﻿using FluentValidation;
using PickItEasy.Application.Common;

namespace PickItEasy.Application.Dtos.Validation
{
    public class BaseDocumentDtoValidator : AbstractValidator<BaseDocumentDto>
    {
        public BaseDocumentDtoValidator()
        {
            RuleFor(baseDocumentDto => baseDocumentDto.Id).NotNull().NotEmpty();
            RuleFor(baseDocumentDto => baseDocumentDto.Name).NotNull().NotEmpty().MaximumLength(EntityConfig.MAX_LENGTH_NAME);
        }
    }
}
