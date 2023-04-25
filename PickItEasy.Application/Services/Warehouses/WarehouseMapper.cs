using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Warehouses
{
    public class WarehouseMapper
    {
        public static Warehouse Map(WarehouseDto dto)
        {
            Warehouse destination = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Active = dto.Active
            };

            return destination;
        }

        public static WarehouseVm Map(Warehouse warehouse)
        {
                WarehouseVm destination = new()
            {
                Id = warehouse.Id,
                Name = warehouse.Name
            };

            return destination;
        }
    }
}
