using FluentValidation;

namespace PickItEasy.Application.Services.Products.Queries.IsExistsById
{
    public class IsExistsByIdProductQueryValidator : AbstractValidator<IsExistsProductByIdQuery>
    {
        public IsExistsByIdProductQueryValidator()
        {
            RuleFor(isExistsByIdProductQuery => isExistsByIdProductQuery.Id).NotNull().NotEmpty();
        }
    }
}
