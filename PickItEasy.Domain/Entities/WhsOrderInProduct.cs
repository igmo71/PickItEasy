namespace PickItEasy.Domain.Entities
{
    public class WhsOrderInProduct : WhsOrderProduct
    {
        public Guid WhsOrderInId { get; set; }
        public WhsOrderIn? WhsOrderIn { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
