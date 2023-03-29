using FluentValidation;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQuery>
    {
        public GetByIdProductQueryValidator()
        {
            RuleFor(getByIdProductQuery => getByIdProductQuery.Id).NotNull().NotEmpty();
        }
    }
}
