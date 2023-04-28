using FluentValidation;

namespace PickItEasy.Application.MediatR.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(getByIdWhsOrderOutQuery => getByIdWhsOrderOutQuery.Id).NotNull().NotEmpty();
        }
    }
}
