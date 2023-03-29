using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Services.WhsOrdersOut.Commands.Delete
{
    public class DeleteWhsOrderOutCommandValidator : AbstractValidator<DeleteWhsOrderOutCommand>
    {
        public DeleteWhsOrderOutCommandValidator()
        {
            RuleFor(deleteWhsOrderOutCommand => deleteWhsOrderOutCommand.Id).NotNull().NotEmpty();
        }
    }
}
