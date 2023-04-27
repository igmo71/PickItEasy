using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities.WhsOrder
{
    public class WhsOrderStatus : Catalog, IHasActive
    {
        public int Value { get; set; }
        public string? Synonym { get; set; }
        public bool Active { get; set; }
    }
}
