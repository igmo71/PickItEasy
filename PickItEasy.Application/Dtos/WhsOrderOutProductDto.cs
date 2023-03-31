namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutProductDto
    {
        public required Guid ProductId { get; set; }
        public required float Count { get; set; }
    }
}
