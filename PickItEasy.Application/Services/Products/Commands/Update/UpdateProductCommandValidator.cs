using FluentValidation;
using FluentValidation.Validators;
using PickItEasy.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(updateProductCommand => updateProductCommand.Id).NotNull().NotEmpty();
            RuleFor(updateProductCommand => updateProductCommand.UpdateProductDto).NotNull().NotEmpty();
            RuleFor(updateProductCommand => updateProductCommand.UpdateProductDto).SetValidator(new UpdateProductDtoValidator());
        }
    }

    internal class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(updateProductDto => updateProductDto.Name).NotNull().NotEmpty().MaximumLength(EntityConfig.MAX_LENGTH_NAME);
        }
    }
}
