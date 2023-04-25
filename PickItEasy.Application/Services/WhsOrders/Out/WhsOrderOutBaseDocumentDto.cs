namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutBaseDocumentDto
    {
        public required Guid DocumentId { get; set; }
        public required string DocumentName { get; set; }
    }
}
