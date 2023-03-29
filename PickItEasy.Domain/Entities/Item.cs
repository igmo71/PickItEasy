using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public abstract class Item : BaseEntity, IHasId, IHasName
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
