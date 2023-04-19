namespace PickItEasy.Domain.Entities
{
    public class WhsOrderStatus : Catalog
    {
        public required int Value { get; set; }
        public required string Synonym { get; set; }
    }
}
