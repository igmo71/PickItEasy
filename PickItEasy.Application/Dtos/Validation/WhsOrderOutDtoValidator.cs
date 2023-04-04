using FluentValidation;
using PickItEasy.Domain.Entities;

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
            RuleFor(whsOrderOutDto => whsOrderOutDto.Products).NotNull().NotEmpty();
            RuleForEach(whsOrderOutDto => whsOrderOutDto.Products).SetValidator(new WhsOrderOutProductDtoValidator());
            RuleFor(WhsOrderOutDto => WhsOrderOutDto.Status).NotNull().Must(status => PickItEasy.Integration.Connectors.Ut1c.WhsOrderOutStatus.Contain(status));
        }
    }
}
