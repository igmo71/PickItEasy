namespace PickItEasy.Domain.Entities
{
    public class WhsOrderBaseDocument : DocumentItem
    {
        public Guid BaseDocumentId { get; set; }
        public BaseDocument? BaseDocument { get; set; }
    }
}
