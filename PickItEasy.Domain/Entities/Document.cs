using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public abstract class Document : Item, IHasId, IHasName, IHasNumber, IHasDateTime, IHasActive
    {
        public required string Number { get; set; }
        public required DateTime DateTime { get; set; }
        public bool Active { get; set; }
    }
}
