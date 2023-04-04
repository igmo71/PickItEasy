using FluentValidation;

namespace PickItEasy.Application.Services.Products.Queries.GetById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(getByIdProductQuery => getByIdProductQuery.Id).NotNull().NotEmpty();
        }
    }
}
