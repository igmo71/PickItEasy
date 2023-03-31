namespace PickItEasy.Application.Dtos
{
    public class WhsOrderOutDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Number { get; set; }
        public required DateTime DateTime { get; set; }

        public required List<WhsOrderOutProductDto> Products { get; set; }
    }
}