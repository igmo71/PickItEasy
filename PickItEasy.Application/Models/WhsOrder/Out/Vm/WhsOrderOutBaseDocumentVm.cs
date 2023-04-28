using Mapster;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutBaseDocumentVm : MappedModel
    {
        public Guid BaseDocumentId { get; set; }
        public string? Name { get; set; }

        public override void Register(TypeAdapterConfig config)
        {
            config.NewConfig<WhsOrderOutBaseDocument, WhsOrderOutBaseDocumentVm>()
                .RequireDestinationMemberSource(true)
                .Map(dst => dst.Name, src => src.BaseDocument != null ? src.BaseDocument.Name : string.Empty);
        }
    }
}
