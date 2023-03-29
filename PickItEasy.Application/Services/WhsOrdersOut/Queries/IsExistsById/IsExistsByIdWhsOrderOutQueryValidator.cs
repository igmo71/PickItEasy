using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
