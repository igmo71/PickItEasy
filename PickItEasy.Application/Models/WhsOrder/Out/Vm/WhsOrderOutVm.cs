using Mapster;
using PickItEasy.Application.Common;
using PickItEasy.Domain.Entities;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutVm : MappedModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }

        public bool Active { get; set; }

        public Warehouse? Warehouse { get; set; }

        public WhsOrderOutStatusVm? Status { get; set; }

        public WhsOrderOutQueueVm? Queue { get; set; }
        public string? QueueNumber { get; set; }

        public DateTime ShipDateTime { get; set; }

        public string? Comment { get; set; }

        public List<WhsOrderOutProductVm>? Products { get; set; }
        public List<WhsOrderOutBaseDocumentVm>? BaseDocuments { get; set; }

        public string? BarcodeBase64 => BarcodeGuidConvert.GetBarcodeBase64(Id);

        public override void Register(TypeAdapterConfig config)
        {
            config.NewConfig<WhsOrderOut, WhsOrderOutVm>()
                .RequireDestinationMemberSource(true)
                .Map(dst => dst.Products, src => src.WhsOrderOutProducts)
                .Map(dst => dst.BaseDocuments, src => src.WhsOrderOutBaseDocuments);
        }
    }
}