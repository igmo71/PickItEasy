namespace PickItEasy.Domain.Entities
{
    public class WhsOrderProduct : DocumentItem
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
     
        public float Count { get; set; }
    }
}