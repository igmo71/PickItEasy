namespace PickItEasy.Domain.Entities
{
    public class WhsOrderQueue : Catalog
    {
        public required int Value { get; set; }
        public required string Synonym { get; set; }
    }
}
