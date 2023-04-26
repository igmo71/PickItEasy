using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.Warehouses
{
    public class WarehouseDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool Active { get; set; }

        /// <summary>
        /// Map from WarehouseDto to Warehouse
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
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
    }
}
