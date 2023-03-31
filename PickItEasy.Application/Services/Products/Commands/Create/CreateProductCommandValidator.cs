using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand => createProductCommand.ProductDto).NotNull().NotEmpty();
            RuleFor(createProductCommand => createProductCommand.ProductDto).SetValidator(new ProductDtoValidator());
        }        
    }
}
