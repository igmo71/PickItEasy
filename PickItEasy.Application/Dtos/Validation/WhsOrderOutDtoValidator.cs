using FluentValidation;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;

namespace PickItEasy.Application.Dtos.Validation
{
    public class WhsOrderOutDtoValidator : AbstractValidator<WhsOrderOutDto>
    {
        public WhsOrderOutDtoValidator()
        {
            RuleFor(whsOrderOutDto => whsOrderOutDto.Id).NotNull().NotEmpty();
            RuleFor(whsOrderOutDto => whsOrderOutDto.Name).NotNull().NotEmpty();
            RuleFor(whsOrderOutDto => whsOrderOutDto.Number).NotNull().NotEmpty();
            RuleFor(whsOrderOutDto => whsOrderOutDto.DateTime).NotNull().NotEmpty();

            RuleFor(whsOrderOutDto => whsOrderOutDto.Status).NotNull();
            //RuleFor(whsOrderOutDto => whsOrderOutDto.Queue).NotNull();
            RuleFor(whsOrderOutDto => whsOrderOutDto.QueueNumber).NotNull().NotEmpty();

            RuleFor(whsOrderOutDto => whsOrderOutDto.Products).NotNull().NotEmpty();
            RuleForEach(whsOrderOutDto => whsOrderOutDto.Products).SetValidator(new WhsOrderOutProductDtoValidator());
        }
    }
}
