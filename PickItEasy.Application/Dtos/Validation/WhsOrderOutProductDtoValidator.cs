using FluentValidation;

namespace PickItEasy.Application.Dtos.Validation
{
    public class WhsOrderOutProductDtoValidator : AbstractValidator<WhsOrderOutProductDto>
    {
        public WhsOrderOutProductDtoValidator()
        {
            RuleFor(whsOrderOutProductDto => whsOrderOutProductDto.ProductId).NotNull().NotEmpty();
            RuleFor(whsOrderOutProductDto => whsOrderOutProductDto.Count).NotNull();
        }
    }
}
