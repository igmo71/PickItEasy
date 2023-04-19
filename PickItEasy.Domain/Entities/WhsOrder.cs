namespace PickItEasy.Domain.Entities
{
    public abstract class WhsOrder : Document
    {
        public string? Comment { get; set; }
     
        public required Guid WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public List<Product>? Products { get; set; }

        public List<BaseDocument>? BaseDocuments { get; set; }
    }
}
