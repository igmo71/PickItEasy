using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
