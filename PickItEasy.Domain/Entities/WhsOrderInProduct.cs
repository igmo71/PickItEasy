namespace PickItEasy.Domain.Entities
{
    public class WhsOrderInProduct : WhsOrderProduct
    {
        public Guid WhsOrderInId { get; set; }
        public WhsOrderIn? WhsOrderIn { get; set; }
    }
}
