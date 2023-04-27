using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class DocumentItemHistory : BaseEntity, IHasDateTime
    {
        public DateTime DateTime { get; set; }
        public Guid DocumentId { get; set; }
        public Guid ItemId { get; set; }
        public string? Message { get; set; }
    }
}
