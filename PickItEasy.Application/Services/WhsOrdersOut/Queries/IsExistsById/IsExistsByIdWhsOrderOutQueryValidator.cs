using FluentValidation;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.IsExistsById
{
    public class IsExistsByIdWhsOrderOutQueryValidator : AbstractValidator<IsExistsByIdWhsOrderOutQuery>
    {
        public IsExistsByIdWhsOrderOutQueryValidator()
        {
            RuleFor(isExistsByIdWhsOrderOutQuery => isExistsByIdWhsOrderOutQuery.Id).NotNull().NotEmpty();
        }
    }
}
