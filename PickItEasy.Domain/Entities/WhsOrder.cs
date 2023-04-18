namespace PickItEasy.Domain.Entities
{
    public abstract class WhsOrder : Document
    {
        public required Guid WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public string? Comment { get; set; }

        public List<Product>? Products { get; set; }
    }
}
