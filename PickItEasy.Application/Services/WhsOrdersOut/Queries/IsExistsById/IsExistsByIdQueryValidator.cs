using FluentValidation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.IsExistsById
{
    public class IsExistsByIdQueryValidator : AbstractValidator<IsExistsByIdQuery>
    {
        public IsExistsByIdQueryValidator()
        {
            RuleFor(isExistsByIdQuery => isExistsByIdQuery.Id).NotNull().NotEmpty();
        }
    }
}
