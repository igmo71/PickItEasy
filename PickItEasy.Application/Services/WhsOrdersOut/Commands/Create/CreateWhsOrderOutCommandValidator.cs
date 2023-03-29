using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Create
{
    internal class CreateWhsOrderOutCommandValidator : AbstractValidator<CreateWhsOrderOutCommand>
    {
        public CreateWhsOrderOutCommandValidator()
        {
            RuleFor(createWhsOrderOutCommand => createWhsOrderOutCommand.CreateWhsOrderOutDto).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutCommand => createWhsOrderOutCommand.CreateWhsOrderOutDto).SetValidator(new CreateWhsOrderOutDtoValidator());
        }
    }

    internal class CreateWhsOrderOutDtoValidator : AbstractValidator<CreateWhsOrderOutDto>
    {
        public CreateWhsOrderOutDtoValidator()
        {
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Id).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Name).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Number).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.DateTime).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Products).NotNull().NotEmpty();
            //RuleFor(createWhsOrderOutDto => createWhsOrderOutDto.Products).SetValidator(new CreateWhsOrderOutProductDtoValidator());
        }
    }

    internal class CreateWhsOrderOutProductDtoValidator : AbstractValidator<CreateWhsOrderOutProductDto>
    {
        public CreateWhsOrderOutProductDtoValidator()
        {
            RuleFor(createWhsOrderOutProductDto => createWhsOrderOutProductDto.ProductId).NotNull().NotEmpty();
            RuleFor(createWhsOrderOutProductDto => createWhsOrderOutProductDto.Count).NotNull();
        }
    }
}
