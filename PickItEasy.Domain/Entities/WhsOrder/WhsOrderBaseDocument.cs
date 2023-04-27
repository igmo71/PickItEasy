namespace PickItEasy.Domain.Entities.WhsOrder
{
    public class WhsOrderBaseDocument : DocumentItem
    {
        public Guid BaseDocumentId { get; set; }
        public BaseDocument? BaseDocument { get; set; }
    }
}
