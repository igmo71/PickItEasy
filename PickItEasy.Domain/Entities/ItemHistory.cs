using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class ItemHistory : BaseEntity, IHasId, IHasDateTime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid DocumentId { get; set; }
        public Guid ItemId { get; set; }
        public string? Message { get; set; }
    }
}
