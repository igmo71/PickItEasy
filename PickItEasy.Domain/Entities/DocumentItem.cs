using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public abstract class DocumentItem : BaseEntity, IHasId
    {
        public Guid Id { get; set; }
    }
}