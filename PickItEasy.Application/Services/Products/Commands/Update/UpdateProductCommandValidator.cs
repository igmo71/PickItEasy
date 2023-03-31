using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(updateProductCommand => updateProductCommand.Id).NotNull().NotEmpty();
            RuleFor(updateProductCommand => updateProductCommand.ProductDto).NotNull().NotEmpty();
            RuleFor(updateProductCommand => updateProductCommand.ProductDto).SetValidator(new ProductDtoValidator());
        }
    }
}
