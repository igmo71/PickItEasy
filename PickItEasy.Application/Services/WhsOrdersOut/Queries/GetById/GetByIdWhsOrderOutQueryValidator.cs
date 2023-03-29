using FluentValidation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdWhsOrderOutQueryValidator : AbstractValidator<GetByIdWhsOrderOutQuery>
    {
        public GetByIdWhsOrderOutQueryValidator()
        {
            RuleFor(getByIdWhsOrderOutQuery => getByIdWhsOrderOutQuery.Id).NotNull().NotEmpty();
        }
    }
}
