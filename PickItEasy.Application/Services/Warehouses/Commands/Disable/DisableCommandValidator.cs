using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.Warehouses.Commands.Disable
{
    public class DisableCommandValidator : AbstractValidator<DisableCommand>
    {
        public DisableCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
