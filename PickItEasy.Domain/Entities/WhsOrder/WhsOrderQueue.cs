using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities.WhsOrder
{
    public class WhsOrderQueue : Catalog, IHasActive
    {
        public int Value { get; set; }
        public string? Synonym { get; set; }
        public bool Active { get; set; }
    }
}
