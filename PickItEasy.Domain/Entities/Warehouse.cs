using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class Warehouse : BaseEntity, IHasId, IHasName, IHasIsActive
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool IsActive { get; set; }
    }
}
