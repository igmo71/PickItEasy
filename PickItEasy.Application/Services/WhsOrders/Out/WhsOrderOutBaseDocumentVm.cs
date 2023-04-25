namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutBaseDocumentVm
    {
        public required Guid BaseDocumentId { get; set; }
        public required string? Name { get; set; }
    }
}
