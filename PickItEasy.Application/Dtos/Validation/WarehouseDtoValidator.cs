using FluentValidation;
using PickItEasy.Application.Common;

namespace PickItEasy.Application.Dtos.Validation
{
    public class WarehouseDtoValidator : AbstractValidator<WarehouseDto>
    {
        public WarehouseDtoValidator()
        {
            RuleFor(warehouseDto => warehouseDto.Id).NotNull().NotEmpty();
            RuleFor(productDto => productDto.Name).NotNull().NotEmpty().MaximumLength(EntityConfig.MAX_LENGTH_NAME);
        }
    }
}
