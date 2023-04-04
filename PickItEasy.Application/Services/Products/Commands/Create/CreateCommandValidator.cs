using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(createCommand => createCommand.ProductDto).NotNull().NotEmpty();
            RuleFor(createCommand => createCommand.ProductDto).SetValidator(new ProductDtoValidator());
        }        
    }
}
