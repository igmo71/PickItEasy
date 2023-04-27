namespace PickItEasy.Domain.Entities.WhsOrder
{
    public abstract class WhsOrder : Document
    {
        public string? Comment { get; set; }

        public Guid WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public List<Product>? Products { get; set; }

        public List<BaseDocument>? BaseDocuments { get; set; }
    }
}
