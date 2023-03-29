using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class DocumentHistory : BaseEntity, IHasId, IHasDateTime
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid DocumentId { get; set; }
        public string? Message { get; set; }
    }
}
