using FluentValidation;
using MediatR;
using PickItEasy.Application.Services.WhsOrderOutStatuses.Queries.Contains;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Dtos.Validation
{
    public class WhsOrderOutDtoValidator : AbstractValidator<WhsOrderOutDto>
    {
        private readonly IMediator _mediator;
        public WhsOrderOutDtoValidator(IMediator mediator)
        {
            _mediator = mediator;
            RuleFor(whsOrderOutDto => whsOrderOutDto.Id).NotNull().NotEmpty();
            RuleFor(whsOrderOutDto => whsOrderOutDto.Name).NotNull().NotEmpty();
            RuleFor(whsOrderOutDto => whsOrderOutDto.Number).NotNull().NotEmpty();
            RuleFor(whsOrderOutDto => whsOrderOutDto.DateTime).NotNull().NotEmpty();
            RuleFor(whsOrderOutDto => whsOrderOutDto.Products).NotNull().NotEmpty();
            RuleForEach(whsOrderOutDto => whsOrderOutDto.Products).SetValidator(new WhsOrderOutProductDtoValidator());
            RuleFor(WhsOrderOutDto => WhsOrderOutDto.Status).NotNull()
                .Must(status => _mediator.Send(new ContainsValueQuery { Value = status }).GetAwaiter().GetResult()); // TODO: Check!
        }
    }
}
