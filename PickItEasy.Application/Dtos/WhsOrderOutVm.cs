using NetBarcode;
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

        public WhsOrderOutStatusVm? Status { get; set; }
        public WhsOrderOutQueueVm? Queue { get; set; }

        public List<WhsOrderOutProductVm>? Products { get; set; }

        public string? BarcodeBase64 => BarcodeGuidConvert.GetBarcodeBase64(Id);
    }
}