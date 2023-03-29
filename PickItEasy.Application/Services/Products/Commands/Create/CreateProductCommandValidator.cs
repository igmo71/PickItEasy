﻿using FluentValidation;
using PickItEasy.Application.Common;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand => createProductCommand.CreateProductDto).NotNull().NotEmpty();
            RuleFor(createProductCommand => createProductCommand.CreateProductDto).SetValidator(new CreateProductDtoValidator());
        }

        public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
        {
            public CreateProductDtoValidator()
            {
                RuleFor(createProductDto => createProductDto.Id).NotNull().NotEmpty();
                RuleFor(createProductDto => createProductDto.Name).NotNull().NotEmpty().MaximumLength(EntityConfig.MAX_LENGTH_NAME);
            }
        }
    }
}
