using FluentValidation;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(getByIdProductQuery => getByIdProductQuery.Id).NotNull().NotEmpty();
        }
    }
}
