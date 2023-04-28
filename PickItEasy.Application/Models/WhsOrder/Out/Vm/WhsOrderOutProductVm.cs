using Mapster;
using PickItEasy.Domain.Entities.WhsOrder.Out;

namespace PickItEasy.Application.Models.WhsOrder.Out.Vm
{
    public class WhsOrderOutProductVm : MappedModel
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public float Count { get; set; }

        public override void Register(TypeAdapterConfig config)
        {
            config.NewConfig<WhsOrderOutProduct, WhsOrderOutProductVm>()
                .RequireDestinationMemberSource(true)
                .Map(dst => dst.Name, src => src.Product != null ? src.Product.Name : string.Empty);
        }
    }
}
