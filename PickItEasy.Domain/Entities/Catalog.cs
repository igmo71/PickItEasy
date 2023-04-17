using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public abstract class Catalog : Item, IHasActive
    {
        public required bool Active { get; set; }
    }
}
