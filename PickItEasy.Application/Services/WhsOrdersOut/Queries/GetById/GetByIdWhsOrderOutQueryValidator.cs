using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Queries.GetById
{
    public class GetByIdWhsOrderOutQueryValidator : AbstractValidator<GetByIdWhsOrderOutQuery>
    {
        public GetByIdWhsOrderOutQueryValidator()
        {
            RuleFor(getByIdWhsOrderOutQuery => getByIdWhsOrderOutQuery.Id).NotNull().NotEmpty();
        }
    }
}
