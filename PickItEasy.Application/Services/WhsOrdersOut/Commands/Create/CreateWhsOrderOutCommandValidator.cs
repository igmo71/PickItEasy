using FluentValidation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommandValidator : AbstractValidator<CreateWhsOrderOutCommand>
    {
        public CreateWhsOrderOutCommandValidator()
        {
            RuleFor(createWhsOrderOutCommand => createWhsOrderOutCommand.WhsOrderOutDto).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutCommand => createWhsOrderOutCommand.WhsOrderOutDto).SetValidator(new WhsOrderOutDtoValidator());
        }
    }

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
        }
    }

    public class WhsOrderOutProductDtoValidator : AbstractValidator<WhsOrderOutProductDto>
    {
        public WhsOrderOutProductDtoValidator()
        {
            RuleFor(whsOrderOutProductDto => whsOrderOutProductDto.ProductId).NotNull().NotEmpty();
            RuleFor(whsOrderOutProductDto => whsOrderOutProductDto.Count).NotNull();
        }
    }
}
