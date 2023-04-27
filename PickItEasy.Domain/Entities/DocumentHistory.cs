using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class DocumentHistory : BaseEntity, IHasDateTime
    {
        public DateTime DateTime { get; set; }
        public Guid DocumentId { get; set; }
        public string? Message { get; set; }
    }
}
