namespace PickItEasy.Domain.Entities
{
    public class WhsOrderOut : WhsOrder
    {
        public List<WhsOrderOutProduct> WhsOrderOutProducts { get; set; } = new();

        public required Guid StatusId { get; set; }
        public required WhsOrderOutStatus Status { get; set; }

        public required Guid QueueId { get; set; }
        public required WhsOrderOutQueue Queue { get; set; }
    }
}
