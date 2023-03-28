using FluentValidation;
using PickItEasy.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(createProductCommand => createProductCommand.CreateProductDto).NotNull();
            RuleFor(createProductCommand => createProductCommand.CreateProductDto).SetValidator(new CreateProductDtoValidator());
        }

        public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
        {
            public CreateProductDtoValidator()
            {
                RuleFor(createProductDto => createProductDto.Id).NotNull();
                RuleFor(createProductDto => createProductDto.Name).NotNull().MaximumLength(EntityConfig.MAX_LENGTH_NAME);
            }
        }
    }
}
