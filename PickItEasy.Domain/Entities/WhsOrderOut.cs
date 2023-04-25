﻿namespace PickItEasy.Domain.Entities
{
    public class WhsOrderOut : WhsOrder
    {
        public Guid StatusId { get; set; }
        public WhsOrderOutStatus? Status { get; set; }

        public Guid QueueId { get; set; }
        public WhsOrderOutQueue? Queue { get; set; }

        public required string QueueNumber { get; set; }

        public DateTime ShipDateTime { get; set; }

        public List<WhsOrderOutProduct> WhsOrderOutProducts { get; set; } = new();

        public List<WhsOrderOutBaseDocument> WhsOrderOutBaseDocuments { get; set; } = new();
    }
}
