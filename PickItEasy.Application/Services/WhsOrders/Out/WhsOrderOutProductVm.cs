namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutProductVm
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public float Count { get; set; }
    }
}
