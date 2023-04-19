namespace PickItEasy.Domain.Entities
{
    public abstract class WhsOrderStatus : Catalog
    {
        public required int Value { get; set; }
        public required string Synonym { get; set; }
    }
}
