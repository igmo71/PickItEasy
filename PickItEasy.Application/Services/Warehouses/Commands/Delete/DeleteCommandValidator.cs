using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.Warehouses.Commands.Delete
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(e => e.WarehouseDto).NotNull().NotEmpty().SetValidator(new WarehouseDtoValidator());
        }
    }
}
