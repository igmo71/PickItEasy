namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public class SearchParameters
    {
        public Guid StatusId { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid UserId { get; set; }
        public string? SearchTerm { get; set; }
        public int Take { get; set; } = 10;
    }
}
