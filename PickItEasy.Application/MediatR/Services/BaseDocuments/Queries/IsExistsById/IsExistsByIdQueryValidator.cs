using FluentValidation;

namespace PickItEasy.Application.MediatR.Services.BaseDocuments.Queries.IsExistsById
{
    public class IsExistsByIdQueryValidator : AbstractValidator<IsExistsByIdQuery>
    {
        public IsExistsByIdQueryValidator()
        {
            RuleFor(isExistsByIdQuery => isExistsByIdQuery.Id).NotNull().NotEmpty();
        }
    }
}
