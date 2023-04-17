using FluentValidation;

namespace PickItEasy.Application.Services.Warehouses.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(getByIdQuery => getByIdQuery.Id).NotNull().NotEmpty();
        }
    }
}
