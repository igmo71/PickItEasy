using FluentValidation;
using PickItEasy.Application.Common;
using PickItEasy.Application.Models.Warehouses;

namespace PickItEasy.Application.MediatR.Validation
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
