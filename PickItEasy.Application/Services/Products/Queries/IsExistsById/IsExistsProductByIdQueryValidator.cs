using FluentValidation;

namespace PickItEasy.Application.Services.Products.Queries.IsExistsById
{
    public class IsExistsProductByIdQueryValidator : AbstractValidator<IsExistsProductByIdQuery>
    {
        public IsExistsProductByIdQueryValidator()
        {
            RuleFor(isExistsByIdProductQuery => isExistsByIdProductQuery.Id).NotNull().NotEmpty();
        }
    }
}
