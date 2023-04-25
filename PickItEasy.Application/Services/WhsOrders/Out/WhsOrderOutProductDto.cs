namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutProductDto
    {
        public required Guid ProductId { get; set; }
        public required float Count { get; set; }
    }
}
