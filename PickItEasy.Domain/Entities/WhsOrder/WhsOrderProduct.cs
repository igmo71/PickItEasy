namespace PickItEasy.Domain.Entities.WhsOrder
{
    public class WhsOrderProduct : DocumentItem
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public float Count { get; set; }
    }
}