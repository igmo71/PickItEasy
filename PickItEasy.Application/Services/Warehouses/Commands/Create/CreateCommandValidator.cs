using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.Services.Warehouses.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(createCommand => createCommand.WarehouseDto).NotNull().NotEmpty().SetValidator(new WarehouseDtoValidator());
        }
    }
}
