using FluentValidation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    public class CreateWhsOrderOutCommandValidator : AbstractValidator<CreateWhsOrderOutCommand>
    {
        public CreateWhsOrderOutCommandValidator()
        {
            RuleFor(createWhsOrderOutCommand => createWhsOrderOutCommand.CreateWhsOrderOutDto).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutCommand => createWhsOrderOutCommand.CreateWhsOrderOutDto).SetValidator(new CreateWhsOrderOutDtoValidator());
        }
    }

    public class CreateWhsOrderOutDtoValidator : AbstractValidator<CreateWhsOrderOutDto>
    {
        public CreateWhsOrderOutDtoValidator()
        {
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Id).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Name).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Number).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.DateTime).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Products).NotNull().NotEmpty();
            RuleForEach(createWhsOrderOutDto => createWhsOrderOutDto.Products).SetValidator(new CreateWhsOrderOutProductDtoValidator());
        }
    }

    public class CreateWhsOrderOutProductDtoValidator : AbstractValidator<CreateWhsOrderOutProductDto>
    {
        public CreateWhsOrderOutProductDtoValidator()
        {
            RuleFor(createWhsOrderOutProductDto => createWhsOrderOutProductDto.ProductId).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutProductDto => createWhsOrderOutProductDto.Count).NotNull();
        }
    }
}
