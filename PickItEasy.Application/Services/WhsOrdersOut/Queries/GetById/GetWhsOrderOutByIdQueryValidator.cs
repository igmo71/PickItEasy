using FluentValidation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetWhsOrderOutByIdQueryValidator : AbstractValidator<GetWhsOrderOutByIdQuery>
    {
        public GetWhsOrderOutByIdQueryValidator()
        {
            RuleFor(getByIdWhsOrderOutQuery => getByIdWhsOrderOutQuery.Id).NotNull().NotEmpty();
        }
    }
}
