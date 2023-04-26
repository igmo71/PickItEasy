namespace PickItEasy.Application.Models.Warehouse
{
    public class WarehouseDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool Active { get; set; }
    }
}
