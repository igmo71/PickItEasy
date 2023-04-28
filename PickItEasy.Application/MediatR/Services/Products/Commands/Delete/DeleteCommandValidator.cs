using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.MediatR.Services.Products.Commands.Delete
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(e => e.ProductDto).NotNull().NotEmpty().SetValidator(new ProductDtoValidator());
        }
    }
}
