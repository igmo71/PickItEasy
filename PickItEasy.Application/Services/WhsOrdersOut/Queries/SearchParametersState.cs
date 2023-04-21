namespace PickItEasy.Application.Services.WhsOrdersOut.Queries
{
    public class SearchParametersState
    {
        public string? Barcode { get; set; }
        public string? SearchTerm { get; set; }
        public Guid? StatusId { get; set; }
        public Guid? WarehouseId { get; set; }
        public Guid? UserId { get; set; }
    }
}
