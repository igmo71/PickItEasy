using FluentValidation;
using PickItEasy.Application.Common;
using PickItEasy.Application.Models.Products;

namespace PickItEasy.Application.Dtos.Validation
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(productDto => productDto.Id).NotNull().NotEmpty();
            RuleFor(productDto => productDto.Name).NotNull().NotEmpty().MaximumLength(EntityConfig.MAX_LENGTH_NAME);
        }
    }
}
