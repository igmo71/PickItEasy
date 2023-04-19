﻿using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.Products.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(updateCommand => updateCommand.Id).NotNull().NotEmpty();
            RuleFor(updateCommand => updateCommand.ProductDto).NotNull().NotEmpty().SetValidator(new ProductDtoValidator());
        }
    }
}
