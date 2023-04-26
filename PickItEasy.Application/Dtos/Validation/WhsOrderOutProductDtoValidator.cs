using FluentValidation;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;

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
