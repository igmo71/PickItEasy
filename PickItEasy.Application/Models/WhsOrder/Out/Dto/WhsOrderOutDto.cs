namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Number { get; set; }
        public required DateTime DateTime { get; set; }

        public required bool Active { get; set; }

        public required Guid WarehouseId { get; set; }

        public required int Status { get; set; }

        public required int Queue { get; set; }
        public required string QueueNumber { get; set; }

        public DateTime ShipDateTime { get; set; }

        public string? Comment { get; set; }

        public required List<WhsOrderOutProductDto> Products { get; set; }
        public required List<WhsOrderOutBaseDocumentDto> BaseDocuments { get; set; }
    }
}