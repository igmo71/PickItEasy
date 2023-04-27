using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities.WhsOrder
{
    public class WhsOrderStatus : Catalog, IHasActive
    {
        public required int Value { get; set; }
        public required string Synonym { get; set; }
        public bool Active { get; set; }
    }
}
