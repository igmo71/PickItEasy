using PickItEasy.Application.Common;
using PickItEasy.Application.Services.WhsOrders.Out.Queues;
using PickItEasy.Application.Services.WhsOrders.Out.Statuses;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }

        public bool Active { get; set; }

        public Warehouse? Warehouse { get; set; }

        public WhsOrderOutStatusVm? Status { get; set; }

        public WhsOrderOutQueueVm? Queue { get; set; }
        public required string QueueNumber { get; set; }

        public DateTime ShipDateTime { get; set; }

        public string? Comment { get; set; }

        public List<WhsOrderOutProductVm> Products { get; set; } = new();
        public List<WhsOrderOutBaseDocumentVm> BaseDocuments { get; set; } = new();

        public string? BarcodeBase64 => BarcodeGuidConvert.GetBarcodeBase64(Id);
    }
}
