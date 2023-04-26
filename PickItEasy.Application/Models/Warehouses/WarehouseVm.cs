using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.Warehouses
{
    public class WarehouseVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        /// <summary>
        /// Map from Warehouse to WarehouseVm
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
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
