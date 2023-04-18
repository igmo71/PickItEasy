namespace PickItEasy.Domain.Entities
{
    public class WhsOrderOutProduct : WhsOrderProduct
    {
        public Guid WhsOrderOutId { get; set; }
        public WhsOrderOut? WhsOrderOut { get; set; }
    }
}
