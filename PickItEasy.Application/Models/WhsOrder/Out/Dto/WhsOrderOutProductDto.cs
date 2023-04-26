namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutProductDto
    {
        public required Guid ProductId { get; set; }
        public required float Count { get; set; }
    }
}
