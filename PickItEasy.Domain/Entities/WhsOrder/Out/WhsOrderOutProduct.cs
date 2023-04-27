namespace PickItEasy.Domain.Entities.WhsOrder.Out
{
    public class WhsOrderOutProduct : WhsOrderProduct
    {
        public Guid WhsOrderOutId { get; set; }
        public WhsOrderOut? WhsOrderOut { get; set; }
    }
}
