using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
