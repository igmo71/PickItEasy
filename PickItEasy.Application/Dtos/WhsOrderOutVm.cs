using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Dtos
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

        public List<WhsOrderOutProductVm>? Products { get; set; }
        public List<WhsOrderOutBaseDocumentVm>? BaseDocuments { get; set; }

        public string? BarcodeBase64 => BarcodeGuidConvert.GetBarcodeBase64(Id);
    }
}