namespace PickItEasy.Domain.Entities.WhsOrder.In
{
    public class WhsOrderInProduct : WhsOrderProduct
    {
        public Guid WhsOrderInId { get; set; }
        public WhsOrderIn? WhsOrderIn { get; set; }
    }
}
