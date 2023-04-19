using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutLookupVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }

        public bool Active { get; set; }

        public string? Comment { get; set; }

        public Warehouse? Warehouse { get; set; }

        public WhsOrderOutStatusVm? Status { get; set; }

        public WhsOrderOutQueueVm? Queue { get; set; }
        public required string QueueNumber { get; set; }

        public DateTime ShipDateTime { get; set; }
    }
}
