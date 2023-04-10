namespace PickItEasy.Domain.Entities
{
    public class WhsOrderOut : WhsOrder
    {
        public List<WhsOrderOutProduct> WhsOrderOutProducts { get; set; } = new();

        public required Guid StatusId { get; set; }
        public  WhsOrderOutStatus? Status { get; set; }

        public Guid QueueId { get; set; }
        public WhsOrderOutQueue? Queue { get; set; }
    }
}
