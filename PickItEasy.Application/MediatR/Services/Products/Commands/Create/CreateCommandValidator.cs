using FluentValidation;
using PickItEasy.Application.MediatR.Validation;

namespace PickItEasy.Application.MediatR.Services.Products.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(createCommand => createCommand.ProductDto).NotNull().NotEmpty().SetValidator(new ProductDtoValidator());
        }
    }
}
