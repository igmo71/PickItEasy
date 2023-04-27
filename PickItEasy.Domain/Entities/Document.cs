using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public abstract class Document : BaseEntity, IHasName, IHasNumber, IHasDateTime, IHasActive
    {
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }
    }
}
