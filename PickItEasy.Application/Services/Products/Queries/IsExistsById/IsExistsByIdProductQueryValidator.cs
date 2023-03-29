using FluentValidation;

namespace PickItEasy.Application.Services.Products.Queries.IsExistsById
{
    public class IsExistsByIdProductQueryValidator : AbstractValidator<IsExistsByIdProductQuery>
    {
        public IsExistsByIdProductQueryValidator()
        {
            RuleFor(isExistsByIdProductQuery => isExistsByIdProductQuery.Id).NotNull().NotEmpty();
        }
    }
}
