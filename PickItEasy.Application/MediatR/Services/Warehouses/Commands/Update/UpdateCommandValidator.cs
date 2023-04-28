using FluentValidation;
using PickItEasy.Application.Dtos.Validation;

namespace PickItEasy.Application.MediatR.Services.Warehouses.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(createCommand => createCommand.WarehouseDto).NotNull().NotEmpty().SetValidator(new WarehouseDtoValidator());
        }
    }
}
