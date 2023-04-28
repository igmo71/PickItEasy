using FluentValidation;

namespace PickItEasy.Application.MediatR.Services.Products.Queries.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(getByIdQuery => getByIdQuery.Id).NotNull().NotEmpty();
        }
    }
}
