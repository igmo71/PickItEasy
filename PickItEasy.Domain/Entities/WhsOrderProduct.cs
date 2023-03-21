namespace PickItEasy.Domain.Entities
{
    public class WhsOrderProduct
    {
        public Guid Id { get; set; }

        public Guid WhsOrderId { get; set; }
        public WhsOrder? WhsOrder { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public float Count { get; set; }
    }
}