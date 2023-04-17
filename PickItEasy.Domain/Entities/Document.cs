using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public abstract class Document : BaseEntity, IHasId, IHasName, IHasNumber, IHasDateTime, IHasActive
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Number { get; set; }
        public required DateTime DateTime { get; set; }
        public bool Active { get; set; }
    }
}
