using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class DocumentItem : BaseEntity, IHasId
    {
        public Guid Id { get; set; }

        public Guid DocumentId { get; set; }
        public Document? Document { get; set; }

        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
    }
}